require('dotenv').config({path: __dirname+"/.env"});
const express = require('express');
const app = express();
const mongoose = require('mongoose');
const bodyParser = require('body-parser');
const cors = require('cors');
const dbstuff = require('./dbstuff');


app.use(cors());
app.use(express.json());

mongoose.connect(process.env.MONGO_URI, { autoIndex : true ,appName :"locationsapi", useNewUrlParser : true, useUnifiedTopology : true })
.then(() => {
    console.log("Connection has been successed");
}).catch((err) => {
    console.log(err)
});

app.use(bodyParser.urlencoded({extended : false}))

app.get("/",(req,res) => {
    res.json({
        Id:1,
        name: "Hello"
    });
})

app.get("/insertdistricts", (req,res) => {
    District.create(districts, (err,docs) => {
        if(err)
        res.json(err)

        res.json(docs);
    })
})

app.get("/insertcities", (req,res) => {
    City.create(cities, (err,docs) => {
        if(err)
        res.json(err)

        res.json(docs);
    })
})

app.get("/deletedistricts", (req,res) => {
    District.deleteMany({}, (err,result) => {
        if(err)
        res.json(err);

        res.json(result);
    });
})

app.get("/deletecities", (req,res) => {
    City.deleteMany({}, (err,result) => {
        if(err)
        res.json(err);

        res.json(result);
    });
})

app.get("/getalldistricts",(req,res) => {
    District.find({}, (err,data) => {
        if(err)
        res.json(err);

        res.json(data);
    })
})

app.get("/getdistrict/:id?",(req,res) => {
    const {id} = req.params;
    
    District.find({CityId: id}, (err,data) => {
        if(err)
        res.json(err);

        res.json(data);
    })
})

app.get("/getallcities",(req,res) => {
    City.find({}, (err,data) => {
        if(err)
        res.json(err);

        res.json(data);
    })
})

const listener = app.listen(process.env.PORT || 3000, () => {
    console.log("App is listening port: "+ listener.address().port)
})   



const cities = dbstuff.createDummyCity();
const districts = dbstuff.createDummyDistrict();
const City = dbstuff.City;
const District = dbstuff.District;