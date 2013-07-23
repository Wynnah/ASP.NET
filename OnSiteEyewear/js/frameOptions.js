function progressive_selected() {
    var myAddLeft = document.getElementById(Controls.myAddLeft);
    var myAddRight = document.getElementById(Controls.myAddRight);

    document.getElementById('addTd').style.display = '';
    document.getElementById('addTd2').style.display = '';

    ValidatorEnable(myAddLeft);
    ValidatorEnable(myAddRight);
}

function progressive_unselected() {
    var myAddLeft = document.getElementById(Controls.myAddLeft);
    var myAddRight = document.getElementById(Controls.myAddRight);

    document.getElementById('addTd').style.display = 'none';
    document.getElementById('addTd2').style.display = 'none';

    ValidatorEnable(myAddLeft, false);
    ValidatorEnable(myAddRight, false);
}

function selectOptionsOn() {
    var x = window.scrollX;
    var y = window.scrollY;
    window.scrollTo = function (x, y) { return true; };

    var ddlSphLeft = document.getElementById(Controls.ddlSphLeft);
    var ddlSphRight = document.getElementById(Controls.ddlSphRight);

    var btnContinue = document.getElementById(Controls.btnContinue);
    var btnCart = document.getElementById(Controls.btnCart);
    var btnGoBack = document.getElementById(Controls.btnGoBack);

    var prescriptionHeader = document.getElementById('prescriptionHeader');
    var lensOptionsHeader = document.getElementById('optionsHeader');

    var prescription = document.getElementById('prescription');
    var lensOptions = document.getElementById('lensOptions');

    var vsPrescription = document.getElementById(Controls.vsPrescription);
    var rb150Index = document.getElementById(Controls.rb150Index);
    var rb159Index = document.getElementById(Controls.rb159Index);
    var rb161Index = document.getElementById(Controls.rb161Index);
    var rb167Index = document.getElementById(Controls.rb167Index);

    var rb150Trans = document.getElementById(Controls.rb150Trans);
    var rb159Trans = document.getElementById(Controls.rb159Trans);
    var rb160Trans = document.getElementById(Controls.rb160Trans);

    rb150Index.checked = false;
    rb159Index.checked = false;
    rb167Index.checked = false;
    if (ddlSphLeft >= -2 && ddlSphLeft <= 2 && ddlSphRight >= -2 && ddlSphRight <= 2) {
        rb150Index.checked = true;
    }
    else if (ddlSphLeft >= -4 && ddlSphLeft < 2 && ddlSphRight >= -4 && ddlSphRight < 2) {
        rb159Index.checked = true;
    }
    else {
        rb167Index.checked = true;
    }

    if (Page_ClientValidate()) {
        prescription.style.display = 'none';
        lensOptions.style.display = '';

        prescriptionHeader.style.backgroundColor = 'White';
        prescriptionHeader.style.border = 'none';
        prescriptionHeader.style.borderBottom = '1px solid black';
        lensOptionsHeader.style.backgroundColor = '#e0e0e0';
        lensOptionsHeader.style.border = '1px solid black';
        lensOptionsHeader.style.borderBottom = 'none';
        lensOptionsHeader.style.padding = '10px';
        btnContinue.style.display = 'none';
        btnCart.style.display = 'inherit';
        btnGoBack.style.display = 'inherit';
        lensOptionsHeader.style.borderBottomColor = "White";
        lensOptionsHeader.style.borderBottomWidth = "2px";
        lensOptionsHeader.style.borderBottomStyle = "solid";
    }
}

function selectOptionsOff() {
    var btnContinue = document.getElementById(Controls.btnContinue);
    var btnCart = document.getElementById(Controls.btnCart);
    var btnGoBack = document.getElementById(Controls.btnGoBack);

    var prescriptionHeader = document.getElementById('prescriptionHeader');
    var lensOptionsHeader = document.getElementById('optionsHeader');

    var prescription = document.getElementById('prescription');
    var lensOptions = document.getElementById('lensOptions');

    var vsPrescription = document.getElementById(Controls.vsPrescription);
    if (Page_ClientValidate()) {
        prescription.style.display = '';
        lensOptions.style.display = 'none';
        prescriptionHeader.style.backgroundColor = '#e0e0e0';
        prescriptionHeader.style.border = '1px solid black';
        prescriptionHeader.style.borderBottom = 'none';
        lensOptionsHeader.style.backgroundColor = 'White';
        lensOptionsHeader.style.border = 'none';
        lensOptionsHeader.style.borderBottom = '1px solid black';
        btnContinue.style.display = 'inherit';
        btnCart.style.display = 'none';
        btnGoBack.style.display = 'none';
    }
}