<?php
require_once 'ApiSimpleGetRestClient.php';
$client = new ApiSimpleGetRestClient('http://www.prevision-meteo.ch/services/json');
$response = $client->get('Neuchatel');
$data = json_decode(($response), True);
echo 'Ville : ' . $data['city_info']['name'] . '</br>';
echo 'Date du jour : ' . $data['current_condition']['date'] . '</br>';
echo 'Temp : ' . $data['current_condition']['tmp'] . 'deg.</br>';
//var_dump($data);
//var_dump($data['fcst_day_0']['hourly_data']['14H00']);
?>

<html>
    <head>
        <meta charset="UTF-8">
            <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
            <link href="css/bootstrap-theme.min.css" rel="stylesheet" type="text/css"/>
            <script src="js/bootstrap.min.js" type="text/javascript"></script>
            
        <title></title>
    </head>
    <body>

    </body>
</html>