using Xlat = ScorchGore.Translation.Translation;

namespace ScorchGore.Extensions;

internal static class TreeNodeCollectionExtensions
{
    public static TreeNode AddTranslatableNode(this TreeNodeCollection to, string key, uint µ)
    {
        var node = to.Add(key: key, text: null);

        node.Tag = new Xlat.Dynaµte(µ, s => node.Text = s);

        return node;
    }
}
