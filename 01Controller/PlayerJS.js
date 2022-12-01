
    var book = document.getElementById("book");
    var audio = document.getElementById("myAudio");
    var controlPanel = document.getElementById("controlPanel")
    var btnArea = document.getElementById("btnArea")
    var info = document.getElementById("info")
    var barVol = document.getElementById("barVol");
    var progress = document.getElementById("progress");
    var music = document.getElementById("music");


    let btnPlay = btnArea.children[0];
    let mute = btnArea.children[6];

    audio.load();
    getDuration();
    setVol();

    var w = 0;
    var r = 0;  //隨機撥放的亂數值
    function getDuration() {
        info.children[1].innerText = getTimeFormat(audio.currentTime) + " / " + getTimeFormat(audio.duration);
    w = (audio.currentTime / audio.duration) * 100;
    progress.style.backgroundImage = "-webkit-linear-gradient(left,aqua,aqua " + w + "%, #f83f4a " + w + "% ,#f83f4a)";
    progress.max = parseInt(audio.duration);
    progress.value = parseInt(audio.currentTime);

    setTimeout(getDuration, 10);


    if (w == 100) {

                if (info.children[2].innerText == "單曲循環") {
        changeMusic(0);
                }
    else if (info.children[2].innerText == "隨機播放") {
        r = Math.floor(Math.random() * music.options.length); //0~到歌曲最終索引值
    r = r - music.selectedIndex;
    changeMusic(r);

                }
                //else if (info.children[2].innerText == "隨機播放" && music.selectedIndex == music.options.length - 1) {
                //    changeMusic(-music.selectedIndex);
                //}
                else if (music.selectedIndex == music.options.length - 1) {
                    if (info.children[2].innerText == "全曲循環") {
        changeMusic(-music.selectedIndex);
                    }
    else {
        stopAudio();
                    }
                }
    else {
        changeMusic(1);
                }
            }
        }

    function setProgressBar() {
        audio.currentTime = progress.value;
        }                                  //進度條

    var min = 0, sec = 0;
    function getTimeFormat(timeSec) {
        //三元表達式 a=a<10? a+5:a-1    若a<10則a+5 否則a-1
        min = parseInt(timeSec / 60);
    sec = parseInt(timeSec % 60);
    min = min < 10 ? "0" + min : min;
    sec = sec < 10 ? "0" + sec : sec;

    return min + ":" + sec;
        }                 //時間換算 分.秒

    function playAudio() {
        audio.play();
    btnPlay.innerText = ";";
    btnPlay.onclick = pauseAudio;
    info.children[0].innerText = "現正播放:" + audio.children[0].title;
        }                                         //播放

    function pauseAudio() {
        audio.pause();
    btnPlay.innerText = "4";
    btnPlay.onclick = playAudio;
    info.children[0].innerText = "音樂暫停";
        }                                     //暫停

    function stopAudio() {
        pauseAudio();
    audio.currentTime = 0;
    info.children[0].innerText = "音樂停止";
        }                                       //停止

    function changeTime(sec) {
        audio.currentTime += sec;
        }                             //快進

    function changeVol() {
        audio.muted = false;
    setVol();
        }                                     //靜音

    function btnVol(a) {
        barVol.value = parseInt(vol.value) + a;
    setVol();
        }                                          //音量紐  barVol最大值是100


    var timeStart, timeEnd, time;

    function getTimeNow() {
            var now = new Date();
    return now.getTime();
        }                              //長按音量紐

    function holdDown(a)                                            //滑鼠按下時觸發
    {
        timeStart = getTimeNow();
    time = setInterval(function ()                      //setInterval會每100毫秒執行一次
    {
        timeEnd = getTimeNow();
                if (timeEnd - timeStart > 500) {
        btnVol(a)
    }
            }, 100);
        }

    function holdUp() {
        clearInterval(time);
        }

    function setVol() {
        vol.value = barVol.value;
    audio.volume = vol.value / 100;
    barVol.style.backgroundImage = "-webkit-linear-gradient(left,aqua,aqua " + barVol.value + "%, #c8c8c8 " + barVol.value + "% ,#c8c8c8)";
    if (barVol.value == 0) {
        mute.innerText = "V";
            }
    else {
        mute.innerText = "U";
            }
        }                                         //設定音量.音量條

    function mutedIcon() {

            if (mute.innerText == "V") {
        mute.innerText = "U";
    audio.muted = false;
    barVol.value = audio.volume * 100;
    vol.value = barVol.value;
    barVol.style.backgroundImage = "-webkit-linear-gradient(left,aqua,aqua " + barVol.value + "%, #c8c8c8 " + barVol.value + "% ,#c8c8c8)";
            }
    else {
        mute.innerText = "V";
    audio.muted = true;
    barVol.value = 0;
    vol.value = barVol.value;
    barVol.style.backgroundImage = "-webkit-linear-gradient(left,aqua,aqua " + barVol.value + "%, #c8c8c8 " + barVol.value + "% ,#c8c8c8)";
            }
        }                               //靜音紐

function changeMusic(a) {
    console.log(music.selectedIndex + a);

    audio.children[0].src = music.options[music.selectedIndex + a].value;
    audio.children[0].title = music.options[music.selectedIndex + a].innerText;
    music.options[music.selectedIndex + a].selected = true;
    audio.load();

    if (btnPlay.innerText == ";") {
        playAudio();
    }
}                    //換歌

    function setLoop() {
        info.children[2].innerText = "單曲循環";
    if (btnArea.children[7].className == "") {
        btnArea.children[7].className = "btnStatusActive";
    btnArea.children[8].className = "";
    btnArea.children[9].className = "";
            }
    else {
        btnArea.children[7].className = "";
    info.children[2].innerText = "正常播放";
            }
        }

    function setRandom() {
        info.children[2].innerText = "隨機播放";
    if (btnArea.children[8].className == "") {
        btnArea.children[8].className = "btnStatusActive";
    btnArea.children[7].className = "";
    btnArea.children[9].className = "";
            }
    else {
        btnArea.children[8].className = "";
    info.children[2].innerText = "正常播放";
            }
        }

    function setAllLoop() {
        info.children[2].innerText = "全曲循環";
    if (btnArea.children[9].className == "") {
        btnArea.children[9].className = "btnStatusActive";
    btnArea.children[7].className = "";
    btnArea.children[8].className = "";
            }
    else {
        btnArea.children[9].className = "";
    info.children[2].innerText = "正常播放";
            }
        }

    function allowDrop(ev) {
        ev.preventDefault();
        }       //停止物件預設行為

    function drag(ev) {
        ev.dataTransfer.setData("text", ev.target.id);
        }

    function drop(ev) {
        ev.preventDefault();
    var data = ev.dataTransfer.getData("text");

    if (ev.target.id == "") {
        ev.target.appendChild(document.getElementById(data));
            }
    else {
        ev.target.parentNode.appendChild(document.getElementById(data));
            }
        }

    var option
    function loadList(i) {
        option = document.createElement("option");
    option.value = book.children[0].children[i].title;
    option.innerText = book.children[0].children[i].innerText;
    music.appendChild(option);
        }
    for (var i = 0; i < book.children[0].children.length; i++) {
        book.children[0].children[i].draggable = "true";
    book.children[0].children[i].id = "song" + i;
    book.children[0].children[i].ondragstart = function () {         //不能傳參數  用空函數呼叫
        drag(event);
            };
    loadList(i);
            //把option附加到music
        }
    changeMusic(0);

    function updateMusic() {
        //1.移除music全部child 從後面開始移除 避免更動索引值  0移掉1變成0造成漏刪
        console.log(book.children[1].innerText);
            for (var i = music.children.length - 1; i >= 0; i--) {
        music.removeChild(music.children[i]);
            }
    if (book.children[1].innerText != "") {

                for (var i = 0; i < book.children[1].children.length; i++) {

        option = document.createElement("option");
    option.value = book.children[1].children[i].title;
    option.innerText = book.children[1].children[i].innerText;
    music.appendChild(option); //附加上去
                }
    changeMusic(0);
            }
    else {
                for (var i = 0; i < book.children[0].children.length; i++) {
        loadList(i);
                }

            }
        }

    function showBook() {
        book.className = book.className == "" ? "hide" : "";
        }

