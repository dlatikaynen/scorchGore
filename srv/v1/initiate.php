<?php

$gamecount = count(glob("." . "????????????????????????????????.ligma"));

if($gamecount > 100) {
    echo "https://http.cat/status/420";
    http_response_code(429);
    exit;
}

$posted = file_get_contents('php://input');
$gametoken = substr(rtrim(strtok($posted, "\n")), 0, 32);
$filename = "{$gametoken}.ligma";

if (is_readable($filename)) {
    echo "Cannot initiate over existing session ($filename)";
    http_response_code(400);
    exit;
}

if (!$fp = fopen($filename, 'w')) {
    echo "Cannot open file ($filename)";
    http_response_code(400);
    exit;
}

$token = rtrim(strtok("\n"));
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
        fclose($fp);
        echo "An initiation cannot possibly consist of more than 10 lines ($filename)";
        http_response_code(400);
        exit;
    }

    $token = strtok("\n");
}

echo "Success, wrote ($lines) lines to file ($filename), #$gamecount";
fclose($fp);
http_response_code(201);