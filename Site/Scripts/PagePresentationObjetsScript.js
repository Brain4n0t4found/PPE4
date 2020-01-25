$(document).ready(function() {
    $(".presentationObjet").mouseenter(function() {
        
        /* Récupération de la valeur de l'attribut "name" de l'élément
         * var nomRecupere = $(this).attr("name");
         * 
         * Recherche de l'id avec le "name" récupéré et récupération de la valeur du champ trouvé
         * var valeurChampRecupere = $("#" + nomRecupere).text();
         * 
         * Attribution de la valeur du champ dans la zone de description d'objets
         * $("#descriptionFiedl").val(valeurChampRecupere); */

        $("#descriptionField").text($("#" + $(this).attr("name")).val());

        // Changement couleur arrière-plan
        $(this).css('background-color', 'grey');
    });

    $(".presentationObjet").mouseleave(function() {
        // Changement couleur arrière-plan
        $(this).css('background-color', 'white');

        // Remplacement du champ de description par le texte par défaut
        $("#descriptionField").text("Ici sera décrit l'objet sur lequel vous passerez le curseur");
    });
});