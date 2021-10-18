//encapsulation using closure
// var counter = 0;
function outerFunc() {
    var counter = 0;

    function innerFunc()
    {
        console.log(this);
        return counter += 1;
    }
    return innerFunc;
}

let obj = {

    method: outerFunc()
};

let count = outerFunc(); // count = innerFunc() {return counter += 1;}
let countTwo = outerFunc();
// console.log(counter); //won't work. counter does not exist here

//closure with IIFE
let countThree = function() {
    let counter = 0;
    return function() 
    {
        return counter++;
    }
}();