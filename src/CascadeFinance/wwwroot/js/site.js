// Write your Javascript code.

function institutionSelected() {
    var selector = document.getElementById("Bank");
    var multiQuestions = ["bbt", "bofa", "capone360", "citi", "pnc", "td", "us", "usaa"];
    var flag = 0;
    for (var i = 0; i < multiQuestions.length; i++)
    {
        if(multiQuestions[i] == selector.options[selector.selectedIndex].value)
        {
            flag = 1;
            break;
        }
    }
    var mFA = document.getElementById("mFA");
    if (flag)
    {
        if(mFA.style.display == "none")
        {
            mFA.style.display = "block";
        }
    }
    else if (mFA.style.display == "block") {
        mFA.style.display = "none";
    }
}