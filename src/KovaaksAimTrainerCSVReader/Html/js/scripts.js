// Options
var config = {
    "canvasContainer":"canvasses",
    "canvasPrefix":"chart-0",
    "titlePrefix":'title-0',
    "chartContainerPrefix":"chartContainer-0",
    "chartDivider":"divider-0"
}

// Elements
var canvasContainer = document.getElementById(config.canvasContainer);



// Utils

// Creates and append HTML
// Returns the canvas element
var createHtml = function(id, title){
    // Create Title
    var h1 = document.createElement("h1");
    h1.id = config.titlePrefix+i;
    h1.innerText = title;

    // Create Canvas    
    var newCanvas = document.createElement("canvas");
    newCanvas.id = config.canvasPrefix+i;

    // Create container
    var container = document.createElement("div");
    container.id = config.chartContainerPrefix+i;

    // Create divider
    var divider = document.createElement("div");
    divider.id = config.chartDivider+i;
    divider.classList.add("divider");    

    // Append to container
    container.appendChild(h1);
    container.appendChild(newCanvas);
    container.appendChild(divider);

    // Append container to canvas container
    canvasContainer.appendChild(container); 
    
    return newCanvas;
}

var dataEnricher = function(options, data){ 
    var Enrichers = options.enrichers;
    var counter = 0;

    if(Enrichers.includes("Colors")){
        // Set Colors
        data.data.datasets.forEach(element => {
            var color = "";
            if(counter < 20){
                 color = Colors[counter];
            }else{
                color = dynamicColors(data.title)
            }
            element.borderColor = color;
            counter++;
        });
        counter = 0;
    }

    if(Enrichers.includes("NoFill")){
        data.data.datasets.forEach(element =>{
            element.fill = false;
        })
    }

    if(Enrichers.includes("Fill")){
        data.data.datasets.forEach(element =>{
            element.fill = true;
        })
    }

    if(Enrichers.includes("NoTension")){
        data.data.datasets.forEach(element =>{
            element.lineTension = 0.1;
        })
    }

    


    return data;
}


// Create script
for(var i=0;i < data.graphs.length; i++){
    // Get Chart info & Enrich
    var chartType = data.graphs[i].chart;
    var chartInfo = options[chartType];
    var chartData = dataEnricher(chartInfo, data.graphs[i]);    
    var title = chartData.title;

    // Create Html
    var chartCanvas = createHtml(i, title);

    // Create Chart
    var chart = new Chart(chartCanvas,{
        type: chartInfo.type,
        data: chartData.data,        
        options: chartInfo.options
    });
}