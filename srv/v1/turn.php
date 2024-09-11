<?php

$gametoken = substr($_GET['token'], 0, 32);
$ordinal = (int)$_GET['ordinal'];

if($ordinal === 0) {
    echo "Cannot write over initial turn";
    http_response_code(400);
    exit;
}

$filename = "{$gametoken}.{$ordinal}.bofa";

if (is_readable($filename)) {
    echo "Cannot write over existing turn ($filename)";
    http_response_code(400);
    exit;
}

if (!$fp = fopen($filename, 'w')) {
    echo "Could not create turn file ($filename)";
    http_response_code(400);
    exit;
}

$patched = file_get_contents('php://input');
$token = rtrim(strtok($patched, "\n"));
$lines = 0;
while ($token !== false) {
    $commandline = rtrim($token);
    if (fwrite($fp, "{$commandline}\n") === false) {
        fclose($fp);
        echo "Cannot write to file ($filename)";
        http_response_code(400);
        exit;
    }

    $lines++;
    if($lines > 10) {
        echo "A turn cannot possibly consist of more than 10 lines ($filename)";
        http_response_code(400);
        exit;
    }

    $token = strtok("\n");
}

echo "Success, wrote ($lines) lines to turn file ($filename)";
fclose($fp);
http_response_code(201);