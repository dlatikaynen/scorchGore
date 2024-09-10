<?php

$gametoken = substr($_GET['token'], 0, 32);
$filename = "{$gametoken}.ligma";

if (is_readable($filename) and is_writable($filename)) {
    $ordinal = (int)$_GET['ordinal'];

    if($ordinal === 0) {
        $contents = file_get_contents($filename);
        echo $contents;
        http_response_code(200);
    }

    if($ordinal > 0) {
        $turnfile = "{$gametoken}.{$ordinal}.bofa";
        if (is_readable($turnfile)) {
            $contents = file_get_contents($turnfile);
            $gamefile = fopen($filename, "a");
            fwrite($gamefile, $contents);
            fclose($gamefile);

            echo $contents;
            http_response_code(200);
        }
        else {
            echo "No #{$ordinal} in ({$gametoken})";
            http_response_code(404);
        }
    }

    if($ordinal < 0) {
        http_response_code(400);
    }
} else {
    echo "There is no active game under ({$gametoken})";
    http_response_code(404);
}