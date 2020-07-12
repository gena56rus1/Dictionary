function openForm(dictionary) {
    var dictionaryOption = dictionary.options[dictionary.selectedIndex];
    if (dictionaryOption.value == 1) {
        document.getElementById("FormEngExplanatoryDictionary").style.display = "block";
        document.getElementById("FormEngRusDictionary").style.display = "none";
        document.getElementById("FormRusExplanatoryDictionary").style.display = "none";
        document.getElementById("FormRusEngDictionary").style.display = "none";
    }
    if (dictionaryOption.value == 2) {
        document.getElementById("FormEngRusDictionary").style.display = "block";
        document.getElementById("FormEngExplanatoryDictionary").style.display = "none";
        document.getElementById("FormRusExplanatoryDictionary").style.display = "none";
        document.getElementById("FormRusEngDictionary").style.display = "none";
    }
    if (dictionaryOption.value == 3) {
        document.getElementById("FormRusExplanatoryDictionary").style.display = "block";
        document.getElementById("FormEngExplanatoryDictionary").style.display = "none";
        document.getElementById("FormEngRusDictionary").style.display = "none";
        document.getElementById("FormRusEngDictionary").style.display = "none";
    }
    if (dictionaryOption.value == 4) {
        document.getElementById("FormRusEngDictionary").style.display = "block";
        document.getElementById("FormEngExplanatoryDictionary").style.display = "none";
        document.getElementById("FormEngRusDictionary").style.display = "none";
        document.getElementById("FormRusExplanatoryDictionary").style.display = "none";
    }
}