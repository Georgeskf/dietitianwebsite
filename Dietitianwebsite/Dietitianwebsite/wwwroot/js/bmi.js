function show_metric() {
    var form_metric = document.getElementById("form_metric");
    var form_american = document.getElementById("form_american");
    var weight = document.getElementById("weight_american");
    var height = document.getElementById("height_american");
    weight.value = "";
    height.value = "";
    form_metric.classList.remove("d-none");
    form_american.classList.add("d-none");
}

function show_american() {
    var form_metric = document.getElementById("form_metric");
    var form_american = document.getElementById("form_american");
    var weight = document.getElementById("weight_metric");
    var height = document.getElementById("height_metric");
    weight.value = "";
    height.value = "";
    form_metric.classList.add("d-none");
    form_american.classList.remove("d-none");
}

function calculate_metric() {
    var weight = document.getElementById("weight_metric").value;
    var height = document.getElementById("height_metric").value;
    var result = weight / (height * height);
    var result_div = document.getElementById("result");
    result_div.classList.remove("d-none");
    if (result < 18.5) {
        result_div.classList.remove("bg-danger");
        result_div.classList.remove("bg-success");
        result_div.classList.remove("text-light");
        result_div.classList.add("bg-warning");
        result_div.classList.add("text-dark");
        if (result < 15) {
            result_div.innerHTML = "<label>Your BMI is " + result + " and you are severly underweight you should eat in a big caloric surplus(500-700 Kcal)</label>"
        }
        else {
            result_div.innerHTML = "<label>Your BMI is " + result + " and you are underweight you should eat in a caloric surplus(200-300 Kcal)</label>"
        }
    }
    else if (result > 25) {
        result_div.classList.remove("bg-warning");
        result_div.classList.remove("bg-success");
        result_div.classList.remove("text-dark");
        result_div.classList.add("bg-danger");
        result_div.classList.add("text-light");
        if (result > 35) {
            result_div.innerHTML = "<label>Your BMI is " + result + " and you are severly overweight you should eat in a big caloric deficit(500-700 Kcal)</label>"
        }
        else {
            result_div.innerHTML = "<label>Your BMI is " + result + " and you are overweight you should eat in a caloric deficit(200-300 Kcal)</label>"
        }
    }
    else {
        result_div.classList.remove("bg-danger");
        result_div.classList.remove("bg-warning");
        result_div.classList.remove("text-light");
        result_div.classList.add("bg-success");
        result_div.classList.add("text-dark");
        result_div.innerHTML = "<label>Your BMI is " + result + "  you have a normal healthy weight</label>"
    }
}

function calculate_american() {
    var weight = document.getElementById("weight_american").value;
    var height = document.getElementById("height_american").value;
    var result = 703 * ( weight / (height * height));
    var result_div = document.getElementById("result");
    result_div.classList.remove("d-none");
    if (result < 18.5) {
        result_div.classList.remove("bg-danger");
        result_div.classList.remove("bg-success");
        result_div.classList.remove("text-light");
        result_div.classList.add("bg-warning");
        result_div.classList.add("text-dark");
        if (result < 15) {
            result_div.innerHTML = "<label>Your BMI is " + result + " and you are severly underweight you should eat in a big caloric surplus(500-700 Kcal)</label>"
        }
        else {
            result_div.innerHTML = "<label>Your BMI is " + result + " and you are underweight you should eat in a caloric surplus(200-300 Kcal)</label>"
        }
    }
    else if (result > 25) {
        result_div.classList.remove("bg-warning");
        result_div.classList.remove("bg-success");
        result_div.classList.remove("text-dark");
        result_div.classList.add("bg-danger");
        result_div.classList.add("text-light");
        if (result > 35) {
            result_div.innerHTML = "<label>Your BMI is " + result + " and you are severly overweight you should eat in a big caloric deficit(500-700 Kcal)</label>"
        }
        else {
            result_div.innerHTML = "<label>Your BMI is " + result + " and you are overweight you should eat in a caloric deficit(200-300 Kcal)</label>"
        }
    }
    else {
        result_div.classList.remove("bg-danger");
        result_div.classList.remove("bg-warning");
        result_div.classList.remove("text-light");
        result_div.classList.add("bg-success");
        result_div.classList.add("text-dark");
        result_div.innerHTML = "<label>Your BMI is " + result + "  you have a normal healthy weight</label>"
    }
}