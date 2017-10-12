'use strict';

const express = require('express');
var fs = require('fs');

// Constants
const PORT = 8080;

// App
const app = express();
app.get('/', function (req, res) {
  fs.readFile('demofile1.html', function(err,data) {
    res.writeHead(200, {'Content-Type': 'text/html'});
    res.write(data);
    res.end();
  });
});

app.listen(PORT);
console.log('Running on http://localhost:' + PORT);

