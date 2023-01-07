var i = 0; // Start point
var images = [];
var time = 3000;

// Image List
images[0] = '/img/slide1.jpg';
images[1] = '/img/slide2.jpg';
images[2] = '/img/slide3.jpg';

// Change Image
function changeImg(){
    document.slide.src = images[i];

    if(i < images.length - 1){
        i++;
    } else {
        i = 0;
    }

    setTimeout("changeImg()", time);
}

window.onload = changeImg;
