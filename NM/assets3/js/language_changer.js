function ChangeLanguage(lang) {

    var imgGE = document.getElementById('ge');
    var imgGB = document.getElementById('gb');
    var imgRU = document.getElementById('ru');

    if (lang === 'GE') {
        imgGE.style.display = 'none';
        imgGB.style.margin = '12px 0 0 50px';
    } 
    
    if (lang === 'GB') {
        imgGB.style.display = 'none';
    }

    if (lang === 'RU') {
        imgRU.style.display = 'none';
    }
}

function ChangeToGE() {
    document.location.href = 'http://caucasoft.ge/';
}

function ChangeToGB() {
    document.location.href = 'http://caucasoft.ge/EN/';
}

function ChangeToRU() {
    document.location.href = 'http://caucasoft.ge/RU/';
}