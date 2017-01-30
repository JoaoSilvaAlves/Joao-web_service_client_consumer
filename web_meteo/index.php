<?php
require_once 'ApiSimpleGetRestClient.php';
$client = new ApiSimpleGetRestClient('http://www.prevision-meteo.ch/services/json');
$response = $client->get('Neuchâtel');
$data = json_decode(($response), True);

if (isset($_POST["dropDown_DaysNumber"])) {
    
}

function VerifCityExists() {
    if (isset($_POST["v_CityToAdd"])) {
        AddCityToList($_POST["v_CityToAdd"]);
    }
}

function AddCityToList($CityToAdd)
{
    echo '<label>';
    echo '<input="checkbox" name="check_list[""value="' . $CityToAdd . '/>' . $CityToAdd . '</label>';
}

//Test d'existence, si variable vide et si le contenu ne dépasse pas 6 objets,
//appel de fonction qui ira construire les zones d'affichage pour la météo
function CallForTables() {
    if (isset($_POST['check_list'])) {
        if (!empty($_POST['check_list'])) {
            if (count($_POST['check_list']) <= 6) {
                foreach ($_POST['check_list'] as $check) {
                    AddCityForecast($check, $_POST["dropDown_DaysNumber"]);
                }
            } else {
                echo 'Vous ne pouvez choisir que 6 villes au même temps.';
            }
        } else {
            echo 'Veuillez sélectionner des villes à afficher' . '</br>';
        }
    } else {
        
    }
}

function AddCityForecast($NameCity, $NumberDays) {
    
}
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
    //document.cookie = sChaine;
</script>

<html>
    <header>
        <meta charset="UTF-8">
        <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
        <link href="css/bootstrap-theme.min.css" rel="stylesheet" type="text/css"/>
        <script src="js/bootstrap.min.js" type="text/javascript"></script>
        <link href="css/cssPerso.css" rel="stylesheet" type="text/css"/>

        <title>Web Service Client Consumer</title>
    </header>

    <body>
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-12">
                    <form class="formVilles" method="post">
                        <div class="col-md-3">
                            <label for="ajouterVille">
                                Ville(s) à afficher
                            </label>
                        </div>

                        <label for="ajouterVille">
                            Nombre de jours
                        </label>

                        <div class="multiselect dropdown">
                            <div class="col-md-3 dropdown">
                                <div class="selectBox" onclick="showCheckboxes()">

                                    <div class="overSelect dropdown"></div>
                                    <select>
                                        <option></option>
                                    </select>
                                </div>
                                <div>
                                    <div id="checkboxes">
                                        <label>
                                            <input type="checkbox"  name="check_list[]" value="Neuchâtel" /> Neuchâtel</label>
                                        <label>
                                            <input type="checkbox"  name="check_list[]" value="La-Chaux-de-Fonds"/> La Chaux-de-Fonds</label>
                                        <label>
                                            <input type="checkbox"  name="check_list[]" value="Bern"/> Berne</label>
                                        <label>
                                            <input type="checkbox"  name="check_list[]" value="Lausanne"/> Lausanne</label>
                                        <?php
                                        VerifCityExists();
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

        <!-- Ajouter ville à la liste déroulante, il faut entrer le nom correct de la ville !-->
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-12">
                    <form role="form" method="post">
                        <div class="form-group">
                            <div>
                                <label for="ajouterVille">
                                    Ville à ajouter à la liste
                                </label>
                            </div>
                            <div class="col-md-3">
                                <input type="text" class="form-control" name="v_CityToAdd"/>
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
                    <form role="form" method="post">
                        <div class="form-group">
                            <div>
                                <label for="enleverVille">
                                    Ville à enlever de la liste
                                </label>
                            </div>
                            <div class="col-md-3">
                                <input type="text" class="form-control" name="v_CityToDelete"/>
                            </div>
                            <div class="col-md-3">
                                <button type="submit" class="btn btn-default "> - </button>
                            </div>
                        </div>
                    </form>     
                </div>
            </div>
        </div>

        <!-- Partie affichage des données météo pour les différentes villes sélectionnées précédemment !--> 
        <div class="col-md-12 ">
            <hr class="traitHorizontal">
        </div>

        <?php
        CallForTables();
        ?>
        <style>
            .tg  {border-collapse:collapse;border-spacing:0;border-width:2px;border-style:solid; margin-left: 10px;text-align: center;}
            .tg td{font-family:Arial, sans-serif;font-size:14px;padding:10px 16px;border-style:solid;border-width:0px;overflow:hidden;word-break:normal;}
            .tg th{font-family:Arial, sans-serif;font-size:18px;font-weight:normal;padding:10px 16px;border-style:solid;border-width:2px;overflow:hidden;word-break:normal;text-align: center;font-weight: bold;}
            .tg .tg-jsj9{font-size:16px;font-family:"Comic Sans MS", cursive, sans-serif !important;;text-align:center;vertical-align:top}
            .tg .tg-by1k{font-weight:bold;font-size:18px;font-family:"Comic Sans MS", cursive, sans-serif !important;;text-align:center;vertical-align:top}
            .tg .tg-yw4l{vertical-align:top}
        </style>

        <div class="col-md-12 ">
            <div class="row">
                <table class="tg">
                    <tr>
                        <th class="tg-baqh" colspan="4"><?php echo 'Météo ' . $data['city_info']['name'] ?></th>
                    </tr>
                    <tr>
                        <td class="tg-baqh" colspan="4">Aujourd'hui</td>
                    </tr>
                    <tr>
                        <td class="tg-yw4l"><?php echo $data['fcst_day_0']['tmin'] ?></td>
                        <td class="tg-yw4l" colspan="3" rowspan="2"><?php echo '<img src="' . $data['current_condition']['icon'] . '"</img>' ?></td>
                    </tr>
                    <tr>
                        <td class="tg-yw4l"><?php echo $data['fcst_day_0']['tmax'] ?></td>
                    </tr>
                    <tr>
                        <td class="tg-yw4l"><?php echo $data['fcst_day_1']['day_long'] ?></td>
                        <td class="tg-yw4l"><?php echo $data['fcst_day_1']['tmin'] ?></td>
                        <td class="tg-yw4l"><?php echo $data['fcst_day_1']['tmax'] ?></td>
                        <td class="tg-yw4l"><?php echo '<img src="' . $data['fcst_day_1']['icon'] . '"</a>' ?></td>
                    </tr>
                    <tr>
                        <td class="tg-yw4l"><?php echo $data['fcst_day_2']['day_long'] ?></td>
                        <td class="tg-yw4l"><?php echo $data['fcst_day_2']['tmin'] ?></td>
                        <td class="tg-yw4l"><?php echo $data['fcst_day_2']['tmax'] ?></td>
                        <td class="tg-yw41"><?php echo '<img src="' . $data['fcst_day_2']['icon'] . '" style="width:100%"</a>' ?></td>
                    </tr>
                    <tr>
                        <td class="tg-yw4l"><?php echo $data['fcst_day_3']['day_long'] ?></td>
                        <td class="tg-yw4l"><?php echo $data['fcst_day_3']['tmin'] ?></td>
                        <td class="tg-yw4l"><?php echo $data['fcst_day_3']['tmax'] ?></td>
                        <td class="tg-yw4l"><?php echo '<img src="' . $data['fcst_day_3']['icon'] . '"</a>' ?></td>
                    </tr>
                    <tr>
                        <td class="tg-yw4l"><?php echo $data['fcst_day_4']['day_long'] ?></td>
                        <td class="tg-yw4l"><?php echo $data['fcst_day_4']['tmin'] ?></td>
                        <td class="tg-yw4l"><?php echo $data['fcst_day_4']['tmax'] ?></td>
                        <td class="tg-yw4l"><?php echo '<img src="' . $data['fcst_day_4']['icon'] . '"</a>' ?></td>
                    </tr>
                </table>
            </div>
        </div>
    </body>
    <footer>

    </footer>
</html>