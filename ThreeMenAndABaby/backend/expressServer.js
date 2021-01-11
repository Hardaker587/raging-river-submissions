// Initialization
const sqlite3 = require('sqlite3').verbose();
const express = require('express');

let db = new sqlite3.Database(':memory:');

const cors = require('cors');
var app = express();
const port = 3333;

app.use(cors());

// HTTP listeners

app.get('/', (req,res) =>{
  res.send('hello')
})

app.post('/api/register', (req, res) => {
  res.send('DB not installed, use Linux server for FSEvents!')

  let db = new sqlite3.Database(':memory:',sqlite3.OPEN_READWRITE, (err) => {
    if (err) {
      return console.error(err.message);
    }
    console.log('Connected to the in-memory SQlite database.');
  });

  db.serialize(() => {
    db.each(`insert into tableName (col1, col2)
    values ({},{})
    `, (err, row) => {
      if (err) {
        console.error(err.message);
      }
      console.log(row.id + "\t" + row.name);
    });
  });
  
  // close the database connection
  db.close((err) => {
    if (err) {
      return console.error(err.message);
    }
    console.log('Close the database connection.');
  });
})

app.post('/api/login', (req, res) => {
  res.send('DB not installed, use Linux server for FSEvents!')

  let db = new sqlite3.Database(':memory:', (err) => {
    if (err) {
      return console.error(err.message);
    }
    console.log('Connected to the in-memory SQlite database.');
  });
  
  // close the database connection
  db.close((err) => {
    if (err) {
      return console.error(err.message);
    }
    console.log('Close the database connection.');
  });

})

app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`)
})