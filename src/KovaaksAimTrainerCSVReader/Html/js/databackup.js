var data = {
    graphs:[{
    "title": "MyTitle!",
    "chart":"standardLineOption",
    "data":{
        "labels":["11/03","12/03","13/03","14/03"],
        "datasets":[{
            "label":"FirstGraph",
            "data":[6,8,7.5,9.75],
            "fill":false,
            "borderColor":dynamicColors(0)
        },{
            "label":"SecondGraph",
            "data":[4,3.5,3,5],
            "fill":false,
            "borderColor":dynamicColors(0)
        }]
    }  
  },{   
    "title": "Super Cool",
    "chart":"standardLineOption",
    "data":{
        "labels":["03","04"],
        "datasets":[{
            "label":"FirstGraph",
            "data":[1,8],
            "fill":false,
            "borderColor":dynamicColors(1)
        },{
            "label":"SecondGraph",
            "data":[4,7],
            "fill":false,
            "borderColor":dynamicColors(1)
        }]
    }  
  }],
  raw:[{}]
};