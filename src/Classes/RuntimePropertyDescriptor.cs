using System.ComponentModel;
using System.Drawing.Design;

namespace ScorchGore.Classes;

/// <summary>
/// Inspired by https://stackoverflow.com/a/16455520/1132334
/// </summary>
public sealed class RuntimePropertyDescriptor : ICustomTypeDescriptor, INotifyPropertyChanged
{
    private Type? _type;
    private AttributeCollection? _attributes;
    private TypeConverter _typeConverter;
    private Dictionary<Type, object>? _editors;
    private EventDescriptor? _defaultEvent;
    private PropertyDescriptor? _defaultProperty;
    private EventDescriptorCollection _events;

    public event PropertyChangedEventHandler? PropertyChanged;

    public RuntimePropertyDescriptor(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        _type = type;
        _typeConverter = TypeDescriptor.GetConverter(type);
        _defaultEvent = TypeDescriptor.GetDefaultEvent(type);
        _defaultProperty = TypeDescriptor.GetDefaultProperty(type);
        _events = TypeDescriptor.GetEvents(type);

        var normalProperties = new List<PropertyDescriptor>();

        Component = new();
        OriginalProperties = TypeDescriptor.GetProperties(type);
        foreach (PropertyDescriptor property in OriginalProperties)
        {
            if (!property.IsBrowsable)
            {
                continue;
            }

            normalProperties.Add(property);
        }

        Properties = new PropertyDescriptorCollection([.. normalProperties]);
        _attributes = TypeDescriptor.GetAttributes(type);
        _editors = new Dictionary<Type, object>();
        
        object? editor = TypeDescriptor.GetEditor(type, typeof(UITypeEditor));
        
        if (editor != null)
        {
            _editors.Add(typeof(UITypeEditor), editor);
        }

        editor = TypeDescriptor.GetEditor(type, typeof(ComponentEditor));
        if (editor != null)
        {
            _editors.Add(typeof(ComponentEditor), editor);
        }

        editor = TypeDescriptor.GetEditor(type, typeof(InstanceCreationEditor));
        if (editor != null)
        {
            _editors.Add(typeof(InstanceCreationEditor), editor);
        }
    }

    public T? GetPropertyValue<T>(string name, T defaultValue)
    {
        if (name == null)
        {
            throw new ArgumentNullException("name");
        }

        foreach (PropertyDescriptor pd in Properties)
        {
            if (pd.Name == name)
            {
                try
                {
                    return (T?)Convert.ChangeType(pd.GetValue(Component), typeof(T));
                }
                catch
                {
                    return defaultValue;
                }
            }
        }

        return defaultValue;
    }

    public void SetPropertyValue(string name, object value)
    {
        ArgumentNullException.ThrowIfNull(name);

        foreach (PropertyDescriptor pd in Properties)
        {
            if (pd.Name == name)
            {
                pd.SetValue(Component, value);

                break;
            }
        }
    }

    internal void OnValueChanged(PropertyDescriptor prop)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop.Name));
    }

    internal static T? GetAttribute<T>(AttributeCollection attributes) where T : Attribute
    {
        if (attributes == null)
        {
            return null;
        }

        foreach (Attribute att in attributes)
        {
            if (typeof(T).IsAssignableFrom(att.GetType()))
            {
                return (T)att;
            }
        }

        return null;
    }

    public sealed class DynamicProperty : PropertyDescriptor, INotifyPropertyChanged
    {
        private readonly Type _type;
        private readonly bool _hasDefaultValue;
        private readonly object? _defaultValue;
        private readonly PropertyDescriptor? _existing;
        private readonly RuntimePropertyDescriptor _descriptor;
        private Dictionary<Type, object>? _editors;
        private bool? _readOnly;
        private bool? _browsable;
        private string? _displayName;
        private string? _description;
        private string? _category;
        private List<Attribute> _attributes = [];

        public event PropertyChangedEventHandler? PropertyChanged;

        internal DynamicProperty(
            RuntimePropertyDescriptor descriptor,
            Type type,
            object? value,
            string name,
            Attribute[] attrs
        ) : base(name, attrs)
        {
            _descriptor = descriptor;
            _type = type;
            Value = value;

            var def = GetAttribute<DefaultValueAttribute>(Attributes);

            if (def == null)
            {
                _hasDefaultValue = false;
            }
            else
            {
                _hasDefaultValue = true;
                _defaultValue = def.Value;
            }

            if (attrs != null)
            {
                foreach (Attribute att in attrs)
                {
                    _attributes.Add(att);
                }
            }
        }

        internal static Attribute[] GetAttributes(PropertyDescriptor existing)
        {
            var atts = new List<Attribute>();

            foreach (Attribute a in existing.Attributes)
            {
                atts.Add(a);
            }

            return [.. atts];
        }

        internal DynamicProperty(RuntimePropertyDescriptor descriptor, PropertyDescriptor existing, object component)
            : this(descriptor, existing.PropertyType, existing.GetValue(component), existing.Name, GetAttributes(existing))
        {
            _existing = existing;
        }

        public void RemoveAttributesOfType<T>() where T : Attribute
        {
            var remove = new List<Attribute>();

            foreach (Attribute att in _attributes)
            {
                if (typeof(T).IsAssignableFrom(att.GetType()))
                {
                    remove.Add(att);
                }
            }

            foreach (Attribute att in remove)
            {
                _attributes.Remove(att);
            }
        }

        public IList<Attribute> AttributesList => _attributes;

        public override AttributeCollection Attributes => new AttributeCollection(_attributes.ToArray());

        public object? Value { get; set; }

        public override bool CanResetValue(object component)
        {
            if (_existing != null)
            {
                return _existing.CanResetValue(component);
            }

            return _hasDefaultValue;
        }

        public override Type ComponentType
        {
            get
            {
                if (_existing != null)
                {
                    return _existing.ComponentType;
                }

                return typeof(object);
            }
        }

        public override object? GetValue(object? component)
        {
            if (_existing != null)
            {
                return _existing.GetValue(component);
            }

            return Value;
        }

        public override string Category
        {
            get
            {
                if (_category != null)
                {
                    return _category;
                }

                return base.Category;
            }
        }

        public void SetCategory(string category)
        {
            _category = category;
        }

        public override string Description
        {
            get
            {
                if (_description != null)
                {
                    return _description;
                }

                return base.Description;
            }
        }

        public void SetDescription(string description)
        {
            _description = description;
        }

        public override string DisplayName
        {
            get
            {
                if (_displayName != null)
                {
                    return _displayName;
                }

                if (_existing != null)
                {
                    return _existing.DisplayName;
                }

                return base.DisplayName;
            }
        }

        public void SetDisplayName(string displayName)
        {
            _displayName = displayName;
        }

        public override bool IsBrowsable
        {
            get
            {
                if (_browsable.HasValue)
                {
                    return _browsable.Value;
                }

                return base.IsBrowsable;
            }
        }

        public void SetBrowsable(bool browsable)
        {
            _browsable = browsable;
        }

        public override bool IsReadOnly
        {
            get
            {
                if (_readOnly.HasValue)
                {
                    return _readOnly.Value;
                }

                if (_existing != null)
                {
                    return _existing.IsReadOnly;
                }

                var att = GetAttribute<ReadOnlyAttribute>(Attributes);

                if (att == null)
                {
                    return false;
                }

                return att.IsReadOnly;
            }
        }

        public void SetIsReadOnly(bool readOnly)
        {
            _readOnly = readOnly;
        }

        public override Type PropertyType
        {
            get
            {
                if (_existing != null)
                {
                    return _existing.PropertyType;
                }

                return _type;
            }
        }

        public override void ResetValue(object component)
        {
            if (_existing != null)
            {
                _existing.ResetValue(component);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
                _descriptor.OnValueChanged(this);

                return;
            }

            if (CanResetValue(component))
            {
                Value = _defaultValue;
                _descriptor.OnValueChanged(this);
            }
        }

        public override void SetValue(object? component, object? value)
        {
            if (_existing != null)
            {
                _existing.SetValue(component, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
                _descriptor.OnValueChanged(this);

                return;
            }

            Value = value;
            _descriptor.OnValueChanged(this);
        }

        public override bool ShouldSerializeValue(object component)
        {
            if (_existing != null)
            {
                return _existing.ShouldSerializeValue(component);
            }

            return false;
        }

        public override object? GetEditor(Type editorBaseType)
        {
            ArgumentNullException.ThrowIfNull(editorBaseType);

            if (_editors != null)
            {
                if ((_editors.TryGetValue(editorBaseType, out object? type)) && (type != null))
                {
                    return type;
                }
            }

            return base.GetEditor(editorBaseType);
        }

        public void SetEditor(Type editorBaseType, object obj)
        {
            ArgumentNullException.ThrowIfNull(editorBaseType);

            if (_editors == null)
            {
                if (obj == null)
                {
                    return;
                }

                _editors = new Dictionary<Type, object>();
            }

            if (obj == null)
            {
                _editors.Remove(editorBaseType);
            }
            else
            {
                _editors[editorBaseType] = obj;
            }
        }
    }

    public PropertyDescriptor AddProperty(Type type, string name, object value, string displayName, string description, string category, bool hasDefaultValue, object defaultValue, bool readOnly)
    {
        return AddProperty(
            type,
            name,
            value,
            displayName,
            description,
            category,
            hasDefaultValue,
            defaultValue,
            readOnly,
            null
        );
    }

    public PropertyDescriptor AddProperty(
        Type type,
        string name,
        object value,
        string displayName,
        string description,
        string category,
        bool hasDefaultValue,
        object defaultValue,
        bool readOnly,
        Type? uiTypeEditor)
    {
        ArgumentNullException.ThrowIfNull(type);
        ArgumentNullException.ThrowIfNull(name);

        var atts = new List<Attribute>();

        if (!string.IsNullOrEmpty(displayName))
        {
            atts.Add(new DisplayNameAttribute(displayName));
        }

        if (!string.IsNullOrEmpty(description))
        {
            atts.Add(new DescriptionAttribute(description));
        }

        if (!string.IsNullOrEmpty(category))
        {
            atts.Add(new CategoryAttribute(category));
        }

        if (hasDefaultValue)
        {
            atts.Add(new DefaultValueAttribute(defaultValue));
        }

        if (uiTypeEditor != null)
        {
            atts.Add(new EditorAttribute(uiTypeEditor, typeof(UITypeEditor)));
        }

        if (readOnly)
        {
            atts.Add(new ReadOnlyAttribute(true));
        }

        var property = new DynamicProperty(this, type, value, name, [.. atts]);
        AddProperty(property);

        return property;
    }

    public void RemoveProperty(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        var remove = new List<PropertyDescriptor>();

        if (Properties != null)
        {
            foreach (PropertyDescriptor pd in Properties)
            {
                if (pd.Name == name)
                {
                    remove.Add(pd);
                }
            }
        }

        foreach (PropertyDescriptor pd in remove)
        {
            Properties?.Remove(pd);
        }
    }

    public void AddProperty(PropertyDescriptor property)
    {
        ArgumentNullException.ThrowIfNull(property);

        Properties?.Add(property);
    }

    public override string ToString()
    {
        return $"{base.ToString()} ({Component})";
    }

    public PropertyDescriptorCollection? OriginalProperties { get; private set; }

    public PropertyDescriptorCollection Properties { get; private set; }

    public RuntimePropertyDescriptor FromComponent(object component)
    {
        ArgumentNullException.ThrowIfNull(component);

        if (_type == null)
        {
            throw new ArgumentNullException(nameof(_type));
        }

        if (!_type.IsAssignableFrom(component.GetType()))
        {
            throw new ArgumentException(null, nameof(component));
        }

        var desc = new RuntimePropertyDescriptor(_type)
        {
            _type = _type,
            Component = component,
            _typeConverter = _typeConverter,
            _editors = _editors,
            _defaultEvent = _defaultEvent,
            _defaultProperty = _defaultProperty,
            _attributes = _attributes,
            _events = _events,
            OriginalProperties = OriginalProperties
        };

        // track values
        var properties = new List<PropertyDescriptor>();

        if (Properties != null)
        {
            foreach (PropertyDescriptor pd in Properties)
            {
                var ap = new DynamicProperty(desc, pd, component);

                properties.Add(ap);
            }
        }

        desc.Properties = new PropertyDescriptorCollection([.. properties]);

        return desc;
    }

    public object Component { get; private set; }
    public string? ClassName { get; set; }
    public string? ComponentName { get; set; }

    AttributeCollection ICustomTypeDescriptor.GetAttributes()
    {
        return _attributes ?? [];
    }

    string? ICustomTypeDescriptor.GetClassName()
    {
        if (ClassName != null)
        {
            return ClassName;
        }

        if (Component != null)
        {
            return Component.GetType().Name;
        }

        if (_type != null)
        {
            return _type.Name;
        }

        return null;
    }

    string? ICustomTypeDescriptor.GetComponentName()
    {
        if (ComponentName != null)
        {
            return ComponentName;
        }

        return Component?.ToString();
    }

    TypeConverter ICustomTypeDescriptor.GetConverter() => _typeConverter;

    EventDescriptor? ICustomTypeDescriptor.GetDefaultEvent() => _defaultEvent;

    PropertyDescriptor? ICustomTypeDescriptor.GetDefaultProperty() => _defaultProperty;

    object? ICustomTypeDescriptor.GetEditor(Type editorBaseType)
    {
        if (_editors?.TryGetValue(editorBaseType, out object? editor) ?? false)
        {
            return editor;
        }

        return null;
    }

    EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[]? attributes) => _events;

    EventDescriptorCollection ICustomTypeDescriptor.GetEvents() => _events;

    PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[]? attributes) => Properties;

    PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties() => Properties;

    object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor? pd) => Component;
}