<?php
require_once 'ApiSimpleGetRestClient.php';
$client = new ApiSimpleGetRestClient('http://www.prevision-meteo.ch/services/json');
$response = $client->get('Neuchatel');
$data = json_decode(($response), True);

//Affichage de la météo sur 5 jours pour Neuchâtel
echo 'Ville : ' . $data['city_info']['name'] . '</br>';
echo 'Date du jour : ' . $data['fcst_day_0']['date'] . '</br>';
echo 'Temp : ' . $data['fcst_day_0']['tmin'] . ' - ' . $data['fcst_day_0']['tmax'] . 'deg.</br>';
echo 'Date du jour : ' . $data['fcst_day_1']['date'] . '</br>';
echo 'Temp : ' . $data['fcst_day_1']['tmin'] . ' - ' . $data['fcst_day_1']['tmax'] . 'deg.</br>';
echo 'Date du jour : ' . $data['fcst_day_2']['date'] . '</br>';
echo 'Temp : ' . $data['fcst_day_2']['tmin'] . ' - ' . $data['fcst_day_2']['tmax'] . 'deg.</br>';
echo 'Date du jour : ' . $data['fcst_day_3']['date'] . '</br>';
echo 'Temp : ' . $data['fcst_day_3']['tmin'] . ' - ' . $data['fcst_day_3']['tmax'] . 'deg.</br>';
echo 'Date du jour : ' . $data['fcst_day_4']['date'] . '</br>';
echo 'Temp : ' . $data['fcst_day_4']['tmin'] . ' - ' . $data['fcst_day_4']['tmax'] . 'deg.</br>' . '</br>';

//var_dump($data);
//var_dump($data['fcst_day_0']['hourly_data']['14H00']);

$numCity = 4;
?>

<script>
    //Source du code : http://stackoverflow.com/questions/17714705/how-to-use-checkbox-inside-select-option
    //Permet de créer le dropdown avec des checkBoxs
    var expanded = false;

    function showCheckboxes() {
        var checkboxes = document.getElementById("checkboxes");
        if (!expanded) {
            checkboxes.style.display = "block";
            expanded = true;
        } else {
            checkboxes.style.display = "none";
            expanded = false;
        }
    }

    document.cookie = sChaine;
</script>

<html>
    <header>
        <meta charset="UTF-8">
        <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
        <link href="css/bootstrap-theme.min.css" rel="stylesheet" type="text/css"/>
        <script src="js/bootstrap.min.js" type="text/javascript"></script>
        <link href="css/cssPerso.css" rel="stylesheet" type="text/css"/>
        
        <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
<script type="text/javascript" src="js/bootstrap-3.1.1.min.js"></script>
<script type="text/javascript" src="js/bootstrap-multiselect.js"></script>

        <title>Web Service Client Consumer</title>
    </header>

    <body>
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-12">
                    <form class="formVilles">
                        <div class="col-md-3">
                            <label for="ajouterVille">
                                Ville à ajouter à la liste
                            </label>
                        </div>

                        <label for="ajouterVille">
                            Nombre de jours
                        </label>

                        <div class="multiselect dropdown">
                            <div class="col-md-3 dropdown">
                                <div class="selectBox" onclick="showCheckboxes()">

                                    <div class="overSelect dropdown"></div>
                                    <select name="dropDown_Cities">
                                        <option>Sélection</option>
                                    </select>
                                </div>
                                <div>
                                    <div id="checkboxes">
                                        <label for="1">
                                            <input type="checkbox" id="1" checked/> Neuchâtel</label>
                                        <label for="2">
                                            <input type="checkbox" id="2" /> La Chaux-de-Fonds</label>
                                        <label for="3">
                                            <input type="checkbox" id="3" /> Berne</label>
                                        <label for="4">
                                            <input type="checkbox" id="4" /> Lausanne</label>
                                        <?php
                                        echo '  <label for="5">
                                                        <input type="checkbox" id="5" />  Geneve</label>';

                                        global $numCity;
                                        ?>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                        <!-- Dropdown pour nombre de jours à afficher -->
                        <div class="col-md-1">
                            <select name="dropDown_DaysNumber">
                                <option>1</option>
                                <option>2</option>
                                <option>3</option>
                                <option>4</option>
                                <option>5</option>
                            </select>
                        </div>
                        
                        <!-- Bouton recharger après sélection de villes à afficher -->
                        <div class="col-md-2">
                            <button type="submit" class="btn btn-default"> Recharger </button>
                        </div>

                        
                    </form>
                </div>
            </div>
        </div>
        
        <form id="form1">

<div style="padding:20px">

<select id="chkveg" multiple="multiple">

    <option value="cheese">Cheese</option>
    <option value="tomatoes">Tomatoes</option>
    <option value="mozarella">Mozzarella</option>
    <option value="mushrooms">Mushrooms</option>
    <option value="pepperoni">Pepperoni</option>
    <option value="onions">Onions</option>

</select>

<br /><br />

<input type="button" id="btnget" value="Get Selected Values" />

<script type="text/javascript">

$(function() {

    $('#chkveg').multiselect({

        includeSelectAllOption: true
    });

    $('#btnget').click(function(){

        alert($('#chkveg').val());
    });
});

</script>

</div>

</form>
        
        <!-- Ajouter ville à la liste déroulante, il faut entrer le nom correct de la ville !-->
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-12">
                    <form role="form">
                        <div class="form-group">
                            <div>
                                <label for="ajouterVille">
                                    Ville à ajouter à la liste
                                </label>
                            </div>
                            <div class="col-md-3">
                                <input type="text" class="form-control" />
                            </div>
                            <div class="col-md-3">

                                <button type="submit" class="btn btn-default"> + </button>
                            </div>
                        </div>

                    </form>
                </div>
            </div>
        </div>
        <!-- Enlever ville de la liste déroulante, il faut entrer le nom correct de la ville !-->
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-12">
                    <form role="form">
                        <div class="form-group">
                            <div>
                                <label for="enleverVille">
                                    Ville à enlever de la liste
                                </label>
                            </div>
                            <div class="col-md-3">
                                <input type="text" class="form-control"/>
                            </div>
                            <div class="col-md-3">
                                <button type="submit" class="btn btn-default "> - </button>
                            </div>
                        </div>
                    </form>     
                </div>

                <div class="col-md-12 ">
                    <hr class="traitHorizontal">
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="row">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-3">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="row">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-3">
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="row">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-3">
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <br>
            </body>
            <footer>

            </footer>
</html>