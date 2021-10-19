"use strict";
//example of typescript class, with access modifier and methods
// class restaurant {
//     id: number;
//     name: string;
//     city: string;
//     state: string;
//     reviews: reviews[] | null;
//     constructor(id: number, name: string, city: string, state: string , reviews: reviews[] | null)
//     {
//         this.id = id;
//         this.name = name;
//         this.city = city;
//         this.state = state;
//         this.reviews = reviews;
//     }
//     public calculateRating(): number
//     {
//         if(this.reviews?.length)
//         {
//             let sum = 0;
//             this.reviews.forEach(review => {
//                 sum += review.rating;
//             });
//             return sum / this.reviews.length;
//         }
//         return 0;
//     }
// }
let populateTable = function (restaurants) {
    //     function createTableRow(resto: restaurant): HTMLElement
    //     {
    //         let tr = document.createElement('tr');
    //         let nameTd = document.createElement('td');
    //         let nameNode = document.createTextNode(resto.name);
    //         let cityTd = document.createElement('td');
    //         let cityNode = document.createTextNode(resto.city);
    //         let stateTd = document.createElement('td');
    //         let stateNode = document.createTextNode(resto.state);
    //         nameTd.appendChild(nameNode);
    //         cityTd.appendChild(cityNode);
    //         stateTd.appendChild(stateNode);
    //         tr.appendChild(nameTd);
    //         tr.appendChild(cityTd);
    //         tr.appendChild(stateTd);
    //         return tr;
    //     }
    //getting the table body element with my combination selector
    let table = document.querySelector('table#restaurants.table');
    //first, I'm going to remove all pre-existing tr's just to make sure my table is clean
    //if table body exists, get all tr elements inside that element, and remove everybody
    //the next line is equivalent to the next if block
    // table?.querySelectorAll('tr').forEach((elem) => elem.remove());
    if (table) {
        table.querySelectorAll('tr').forEach((elem) => elem.remove());
    }
    //next, I'm going to loop through the array of restaurants and create tr element and fill it up with corresponding data.
    restaurants.forEach((resto) => {
        // let tr = createTableRow(resto);
        // tableBody?.appendChild(tr);
        if (table) {
            let lastRowNum = table.tBodies[0].rows.length;
            let row = table.insertRow(lastRowNum);
            let name = row.insertCell(0);
            let city = row.insertCell(1);
            let state = row.insertCell(2);
            name.innerHTML = resto.name;
            city.innerHTML = resto.city;
            state.innerHTML = resto.state;
        }
    });
};
function getAllRestaurants() {
    let url = "https://restoreviewsapi.azurewebsites.net/api/restaurant";
    fetch(url, {
        method: 'GET',
        headers: {
            'Access-Control-Allow-Origin': "*"
        }
    }).then(res => res.json()).then((resbody) => {
        populateTable(resbody);
        console.log(resbody);
    });
}
