var chartColors = []
var Colors = [
    "rgb(230, 25, 75)",
    "rgb(60, 180, 75)",
    "rgb(255, 225, 25)",
    "rgb(0, 130, 200)",
    "rgb(245, 130, 48)",
    "rgb(145, 30, 180)",
    "rgb(70, 240, 240)",
    "rgb(240, 50, 230)",
    "rgb(210, 245, 60)",
    "rgb(250, 190, 190)",
    "rgb(0, 128, 128)",
    "rgb(230, 190, 255)",
    "rgb(170, 110, 40)",
    "rgb(255, 250, 200)",
    "rgb(128, 0, 0)",
    "rgb(170, 255, 195)",
    "rgb(128, 128, 0)",
    "rgb(255, 215, 180)",
    "rgb(0, 0, 128)",
    "rgb(128, 128, 128)"
]

var dynamicColors = function(chart) {    
    // default true
    var isNewColor = true;
    var color;
    do{
        // create color
        color = randomColor()
        isNewColor = !(chartColors[chart] && chartColors[chart].includes(color) && !Colors.includes(color));

        if(isNewColor){
            // Create new collection
            if(!chartColors[chart]){
                chartColors[chart] = [];
            }

            // Add to collection
            chartColors[chart].push(color);
        }        
     }while(!isNewColor);
     
     return color;
 };

 var randomColor = function() {
    var r = Math.floor(Math.random() * 255);
    var g = Math.floor(Math.random() * 255);
    var b = Math.floor(Math.random() * 255);

    return "rgb(" + r + ", " + g + ", " + b + ")";
 };

