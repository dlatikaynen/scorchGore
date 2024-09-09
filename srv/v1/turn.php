<?php

$posted = file_get_contents('php://input');
$gametoken = rtrim(strtok($posted, "\n"));
$filename = "{$gametoken}.ligma";

// Let's make sure the file exists and is writable first.
//if (is_writable($filename)) {
    // In our example we're opening $filename in append mode.
    // The file pointer is at the bottom of the file hence
    // that's where $somecontent will go when we fwrite() it.
    if (!$fp = fopen($filename, 'w')) {
         echo "Cannot open file ($filename)";
         exit;
    }

    // Write $somecontent to our opened file.
    if (fwrite($fp, $posted) === FALSE) {
        echo "Cannot write to file ($filename)";
        exit;
    }

    echo "Success, wrote ($posted) to file ($filename)";

    fclose($fp);

//} else {
//    echo "The file $filename is not writable";
//}

// echo $posted;
http_response_code(201);