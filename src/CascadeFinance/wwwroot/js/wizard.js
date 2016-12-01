
function findTotal() {
    var sum = 0;
    var inputs = document.getElementsByTagName("input");
    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].type == "number" && inputs[i].name != "TotalExpenses") {
            if (inputs[i].name == "MonthlyIncome")
            {
                sum += parseFloat(inputs[i].value);
            }
            else if(parseFloat(inputs[i].value) > 1)
            {
                sum += parseFloat(inputs[i].value) * -1;
            }
        }
    }
    for (i = 0; i <= inputs.length; i++) {
        if(inputs[i].name == "TotalExpenses")
        {
            inputs[i].value = sum;
            break;
        }
    }
    
}