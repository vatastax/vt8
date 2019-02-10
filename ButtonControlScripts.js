//Function to Detect the Double Click of User

function ClientSideClick(myButton) {
    // Client side validation
    if (typeof (Page_ClientValidate) == 'function') {
        if (Page_ClientValidate() == false)
        { return false; }
    }

    //make sure the button is not of type "submit" but "button"
    if (myButton.getAttribute('type') == 'button') {
        // diable the button
        myButton.disabled = true;
        myButton.className = "btn-inactive";
        myButton.value = "processing...";
    }
    return true;
}