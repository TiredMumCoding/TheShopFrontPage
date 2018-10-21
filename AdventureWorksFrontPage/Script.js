
function mainMenu() {
    var img = document.getElementsByClassName("img1")
    var img2 = document.getElementsByClassName("img2")
    for (i = 0; i < img2.length; i++) {
        var oldSrc = img2[i].src
        var num = oldSrc.charAt(oldSrc.length - 5)
        var index = oldSrc.lastIndexOf(num)
        if (num < 4) {
            num = parseInt(num) + 1
        }
        else { num = 1 }
        var newSrc = oldSrc.substring(0, index) + num + oldSrc.substring(index + 1, oldSrc.length)
        //img2[i].style.zIndex = -1
        img2[i].src = newSrc

        fade(img[i], img2[i], swapImage)
    }
}

function fade(e1, e2, callback) {
    e1.style.opacity = 1
    var op = 1
    var increment = +0.1
    var check = true

    var timer = setInterval(function () {
     op = op - increment
     e1.style.opacity = op
     if (op <= 0) {
      check = false
      clearInterval(timer)
      }
    }, 50)

      var checking = setInterval(function () {
      if (!check) {
       callback(e1, e2)
       clearInterval(checking)
       };
    }, 50)


}

function swapImage(e1, e2) {
    e1.src = e2.src
}


function subMenu() {

    var hdn = document.getElementById("ContentPlaceHolder1_hfaccordion")
    var last = hdn.value
    var last_arr = last.split(",")
    if (last != "") {
        for (var p = 0; p < last_arr.length; p++) {
            var pan = document.getElementsByClassName(last_arr[p])
            pan[0].style.display = "block"
        }
            }
 

    var acc = document.getElementsByClassName("accordion")
    for (var i = 0; i < acc.length; i++) {
        acc[i].onclick = handleClick
    }
}

function handleClick(e) {
    var element = e.currentTarget
    var panel = element.nextElementSibling
    var active = panel.className
    var hdn = document.getElementById("ContentPlaceHolder1_hfaccordion")
    if (panel.style.display === "block") {
        panel.style.display = "none"
        var hdn_arr = hdn.value.split(",")
        var index = hdn_arr.indexOf(active)
        if (index != -1) { hdn_arr.splice(index, 1) }
        hdn.value = hdn_arr.toString()
    }
    else {
        panel.style.display = "block"
        if (hdn.value === "") { hdn.value = active }
        else { hdn.value = hdn.value + "," + active }
    }
}

    var pathname = window.location.pathname
if (pathname === "/MainMenu.aspx") {
    window.onload = setInterval (mainMenu, 5000)
}
if (pathname === "/subMenu.aspx") { window.onload = subMenu }



//function subMenu() {

    //var hdn = document.getElementById("ContentPlaceHolder1_hfaccordion")
    //var last = hdn.value
    //if (last != "") {
       // var pan = document.getElementsByClassName(last)
       // pan[0].style.display = "block"
   // }

//
  //  var acc = document.getElementsByClassName("accordion")
   // for (var i = 0; i < acc.length; i++) {
    //    acc[i].onclick = handleClick
    //}
//}

//function handleClick(e) {
   // var element = e.currentTarget
   // var test = element.nextElementSibling.nodename
   // var panel = element.nextElementSibling
   // if (panel.style.display === "block") {
      //  panel.style.display = "none"
       // var hdn = document.getElementById("ContentPlaceHolder1_hfaccordion")
       // hdn.value = ""
    //}
    //else {
      //  panel.style.display = "block"
      //  var active = panel.className
      //  var hdn = document.getElementById("ContentPlaceHolder1_hfaccordion")
       // hdn.value = active
    //}
//}