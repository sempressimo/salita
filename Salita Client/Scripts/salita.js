//
// Variables
//
var SalitaVersion = "beta 2.0";

//
// Images
//
var floor1 = new Image();
var customer_neutral = new Image();
var customer_medium = new Image();
var customer_bad = new Image();
var customer_selected = new Image();
var chair_down = new Image();
var chair_up = new Image();
var chair_left = new Image();
var chair_right = new Image();
var chair_down_w = new Image();
var chair_up_w = new Image();
var chair_left_w = new Image();
var chair_right_w = new Image();
var bg01 = new Image();
var alert_img = new Image();
var service_cafe = new Image();
var service_transport = new Image();
var service_water = new Image();
var service_can = new Image();
var pop_up_bk = new Image();
var pop_up_cafe = new Image();
var pop_up_water = new Image();
var pop_up_soda = new Image();
var pop_up_taxi = new Image();
var exit = new Image();
var stickynote = new Image();

var pop_x = 0;
var pop_y = 0;

var btn_water_x = 0;
var btn_water_y = 0;

var btn_soda_x = 0;
var btn_soda_y = 0;

var btn_cafe_x = 0;
var btn_cafe_y = 0;

var btn_taxi_x = 0;
var btn_taxi_y = 0;

var btn_change_mood_x = 0;
var btn_change_mood_x2 = 0;
var btn_change_mood_x3 = 0;
var btn_change_mood_y = 0;

var Water_Count = 0;
var Coffee_Count = 0;
var Soda_Count = 0;
var Transport_Count = 0;

//
// Sounds
//
var sndClick = new Audio();

//
// Mouse Control
//
var MouseIsDown = false;
var mouse_x = new Number();
var mouse_y = new Number();
var sel_tile_x = new Number();
var sel_tile_y = new Number();
var old_sel_tile_x = new Number();
var old_sel_tile_y = new Number();

//
// App Logic
//
var CustomersCount = 0;
var customerSelected = false;
var customerIndex = -1;
var customerInSeat = false;

var customer_ID = new Number();

var SelectedCustomerName = "Ninguno";
var SelectedCustomerTime = "N/A";
var SelectedCustomerTime_Value = 0;
var SelectedCustomerTime_Mood = "G";
var SelectedCustomerWaitingFor = "N/A";
var SelectedTileValue = new Number();

var SelectedCustomerWaterService = false;
var SelectedCustomerRefreshmentService = false;
var SelectedCustomerCoffeeService = false;
var SelectedCustomerTransportationService = false;

var SelectedCustomerWaterService_Key = -1;
var SelectedCustomerRefreshmentService_Key = -1;
var SelectedCustomerCoffeeService_Key = -1;
var SelectedCustomerTransportationService_Key = -1;

var Selected_Icon = "";

var customerTime = Date.now();
var RenderState = "Salita";

var diffMins = 0;

var alert_blink = 0;

var draw_stickynote = false;
var stickynote_text = "";

//
// Debug Vars
//
var elapsedTime = 0;
var holdDownTimer = 0; // Time that mouse is pressed
var MouseClickLogic = "N/A";
var doc_scroll_left = 0;
var doc_element_scroll_left = 0;

//
// JSon queries state
//
var CustomerLoadQueryState = "Loading";
var UpdateQueryState = "Loading";

var CustomersArray = null;
var NeedsArray = null;

var canvas = null;

//
// Map Properties
//
var map_top_margin = 86;
var tile_Size = 64;
var map_columns = 12;
var map_rows = 12;
var chairs_tiles_max = 8; // End index (and count)  for chair tiles

// Map Tiles Codes
// 0: Floor 
// 1: Chair down black
// 2: Chair up black
// 3: Chair left black
// 4: Chair right  black
// 5: Chair down white
// 6: Chair up white
// 7: Chair left white
// 8: Chair right white
// 9: Exit
var MapData =
    [
        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5],
        [0, 0, 0, 0, 4, 0, 0, 0, 3, 0, 6, 6],
        [9, 0, 0, 0, 4, 0, 0, 0, 3, 0, 0, 0],
        [0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 9],
        [0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0],
        [4, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0],
        [0, 2, 2, 2, 2, 0, 0, 4, 0, 0, 0, 0],
        [0, 1, 1, 1, 0, 0, 0, 4, 0, 0, 0, 0],
        [0, 0, 0, 0, 3, 0, 0, 4, 0, 0, 0, 8],
        [0, 0, 0, 0, 3, 0, 0, 4, 0, 0, 0, 8],
        [0, 2, 2, 2, 0, 0, 0, 0, 2, 2, 0, 8]
    ];

//var global_uri = "http://localhost:8395/api/visit";
var global_uri = "http://loungewebapi.azurewebsites.net/api/visit";
//var global_uri = "http://salitaagapi.azurewebsites.net/api/visit";

//var global_uri_needs = "http://localhost:8395/api/CustomerNeed";
var global_uri_needs = "http://loungewebapi.azurewebsites.net/api/CustomerNeed";
//var global_uri_needs = "http://salitaagapi.azurewebsites.net/api/CustomerNeed";

var chat;

//var input = new CanvasInput({canvas: document.getElementById('salitacanvas')});


//
// UI modal form functions
//
function addServiceToCustomer()
{

    UpdateQueryState = "Updating Customer";

    var Note = $('#txtServiceNote').val();

    var sid = SelectedCustomerRefreshmentService_Key;

    callAjaxMethod("POST", 'default.aspx/SetService', '{Customer_ID: "' + customer_ID + '", Service_ID: ' + sid + ', Note: "' + Note + '" }', 2);
}

function fulfillServiceToCustomer() {

    UpdateQueryState = "Updating Customer";

    var Note = $('#txtServiceNote').val();

    var sid = -1;

    if (Selected_Icon == "Water")
    {
        sid = SelectedCustomerWaterService_Key;
    }
    else if (Selected_Icon == "Soda")
    {
        sid = SelectedCustomerRefreshmentService_Key;
    }
    else if (Selected_Icon == "Coffee")
    {
        sid = SelectedCustomerCoffeeService_Key;
    }
    else if (Selected_Icon == "Transportation")
    {
        sid = SelectedCustomerTransportationService_Key;
    }

    callAjaxMethod("POST", 'default.aspx/FullfillService', '{ID: ' + sid + ', Note: "' + Note + '" }', 3);
}

//
// Functions
//
function sendJSonRequest(uri, Array_to_update) {

    $.ajax({ type: "GET", url: uri })
        .done(function (data) {
            if (Array_to_update == "Visits")
            {
                CustomersArray = data;
            }
            else if (Array_to_update == "Needs")
            {
                NeedsArray = data;
            }
            CustomerLoadQueryState = "Finished"
        })
        .error(function (jqXHR, textStatus, errorThrown)
        {
            alert("sendJSonRequest(" + uri + "): textStatus: " + textStatus);
        });
}

function callAjaxMethod(_type, _url, _parameters, popup_id) {

    //To prevent postback from happening as we are ASP.Net TextBox control

    //If we had used input html element, there is no need to use ' e.preventDefault()' as posback will not happen

    //e.preventDefault();

    $.ajax({
        type: _type,
        url: _url,
        data: _parameters,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response)
        {
            UpdateQueryState = "Finished";

            if (popup_id == 1) {

                btn_water_y = 400;

                RenderState = "Salita";

            }
            else if (popup_id == 2)
            {
                $('#txtServiceNote').val("");
                dialog.dialog("close");
            }
            else if (popup_id == 3)
            {
                $('#txtServiceNote').val("");
                dialog_Fulfill.dialog("close");
            }

            // Call the Send method on the hub. 
            chat.server.send("");

        },
        failure: function (response)
        {
            alert("Error in calling Ajax:" + response.d);
        }
    });
}

function init() {

    $("#my_textbox").hide(); //Jquery

    CustomerLoadQueryState = "Loading";

    // Load Images
    bg01.src = "images/background.jpg";

    //floor1.src = 'images/floor0.png';

    // Initialise the collision sound
    //sndClick = document.getElementById("clicksound");
    sndClick.src = "sounds/click.wav";

    customer_neutral.src = "images/customer_neutral.png";
    customer_medium.src = "images/face_idle.png";
    customer_bad.src = "images/face_bad.png";
    customer_selected.src = "images/face_sel.png";
    chair_down.src = "images/chair_down.png";
    chair_up.src = "images/chair_up.png";
    chair_left.src = "images/chair_left.png";
    chair_right.src = "images/chair_right.png";
    chair_down_w.src = "images/chair_down_w.png";
    chair_up_w.src = "images/chair_up_w.png";
    chair_left_w.src = "images/chair_left_w.png";
    chair_right_w.src = "images/chair_right_w.png";
    alert_img.src = "images/alert.png";
    service_cafe.src = "images/service_cafe.png";
    service_transport.src = "images/service_transport.png";
    service_water.src = "images/service_water.png";
    service_can.src = "images/service_soda.png";
    pop_up_bk.src = "images/pop_back.png";
    pop_up_cafe.src = "images/pop_cafe.png";
    pop_up_water.src = "images/pop_water.png";
    pop_up_soda.src = "images/pop_soda.png";
    pop_up_taxi.src = "images/pop_taxi.png";
    exit.src = "images/exit.png";
    stickynote.src = "images/stickynote.png";

    canvas = document.getElementById('salitacanvas');

    canvas.addEventListener("mousedown", doMouseDown, false);

    canvas.addEventListener("mouseup", doMouseUp, false);

    canvas.addEventListener("touchstart", doMouseDown, false);

    canvas.addEventListener("touchend", doMouseUp, false);

    UpdateJsonArrays();

    window.requestAnimationFrame(draw);

    $(function ()
    {
        // Declare a proxy to reference the hub. 
        chat = $.connection.updateHub;

        $.connection.hub.start().done(function () {

        }).fail(function (error) {
            alert('Invocation of start failed. Error: ' + error)
        });

        // Create a function that the hub can call to broadcast messages.
        chat.client.broadcastMessage = function (name) {
            //TODO: See if something is needed here
            UpdateJsonArrays();
        };
    });
}

function UpdateJsonArrays()
{
    sendJSonRequest(global_uri, "Visits");
    sendJSonRequest(global_uri_needs, "Needs");

    //callAjaxMethod("POST", 'http://localhost:1189/default.aspx/GetAllNeeds', '', 99);
}

function drawMap(tile_size, ctx) {

    var index = 0;

    for (r = 0; r < map_rows; r++) {
        for (c = 0; c < map_columns; c++) {

            var TileValue = MapData[r][c];

            var x_cursor = c;
            var y_cursor = r;

            if (TileValue == 0) {
                // Draw nothing
                // Canvas has a background
            }
            else if (TileValue == 1) {
                // Down
                ctx.drawImage(chair_down, x_cursor * tile_size, (y_cursor * tile_size) + map_top_margin, tile_size, tile_size);
            }
            else if (TileValue == 2) {
                // Up
                ctx.drawImage(chair_up, x_cursor * tile_size, (y_cursor * tile_size) + map_top_margin, tile_size, tile_size);
            }
            else if (TileValue == 3) {
                // Left
                ctx.drawImage(chair_left, x_cursor * tile_size, (y_cursor * tile_size) + map_top_margin, tile_size, tile_size);
            }
            else if (TileValue == 4) {
                // Right
                ctx.drawImage(chair_right, x_cursor * tile_size, (y_cursor * tile_size) + map_top_margin, tile_size, tile_size);
            }
            else if (TileValue == 5) {
                // Down
                ctx.drawImage(chair_down_w, x_cursor * tile_size, (y_cursor * tile_size) + map_top_margin, tile_size, tile_size);
            }
            else if (TileValue == 6) {
                // Up
                ctx.drawImage(chair_up_w, x_cursor * tile_size, (y_cursor * tile_size) + map_top_margin, tile_size, tile_size);
            }
            else if (TileValue == 7) {
                // Left
                ctx.drawImage(chair_left_w, x_cursor * tile_size, (y_cursor * tile_size) + map_top_margin, tile_size, tile_size);
            }
            else if (TileValue == 8) {
                // Right
                ctx.drawImage(chair_right_w, x_cursor * tile_size, (y_cursor * tile_size) + map_top_margin, tile_size, tile_size);
            }
            else if (TileValue == 9) {
                // Right
                ctx.drawImage(exit, x_cursor * tile_size, (y_cursor * tile_size) + map_top_margin, tile_size, tile_size);
            }

            index++;
        }
    }
}

function drawCustomers(tile_size, ctx)
{
    alert_blink += 1;

    CustomersCount = 0;

    $.each(CustomersArray, function (key, value) {

        var x_pos = value.Seat_X * tile_size;
        var y_pos = value.Seat_Y * tile_size;

        if (customerSelected == true && customer_ID == value.Customer_ID)
        {
            ctx.drawImage(customer_selected, x_pos, y_pos + map_top_margin, tile_size, tile_size);
        }
        else
        {
            UpdateMinsWaiting(value.VisitDate);

            if (value.Mood == "G")
            {
                ctx.drawImage(customer_neutral, x_pos, y_pos + map_top_margin, tile_size, tile_size);
            }
            else if (value.Mood == "N")
            {
                ctx.drawImage(customer_medium, x_pos, y_pos + map_top_margin, tile_size, tile_size);
            }
            else
            {
                ctx.drawImage(customer_bad, x_pos, y_pos + map_top_margin, tile_size, tile_size);
            }  
        }

        if (CheckIfCustomerHasNeeds(value.Customer_ID))
        {
            if (alert_blink >= 30) 
            {
                var Alert_OffSet = 16;

                ctx.drawImage(alert_img, x_pos + Alert_OffSet, y_pos + map_top_margin - Alert_OffSet, tile_size, tile_size);

                if (alert_blink >= 60) {
                    alert_blink = 0;
                }
            }
        }

        CustomersCount++;
    });
}

function CheckCustomerNeeds(Customer_ID)
{

    SelectedCustomerWaterService = false;
    SelectedCustomerRefreshmentService = false;
    SelectedCustomerTransportationService = false;
    SelectedCustomerCoffeeService = false;

    if (NeedsArray != null)
    {
        $.each(NeedsArray, function (key, value)
        {
            if (value.Customer_ID == Customer_ID) {
                if (value.RequestedService_ID == 1) {
                    SelectedCustomerWaterService = true;
                    SelectedCustomerWaterService_Key = value.CustomerNeed_ID;
                }
                else if (value.RequestedService_ID == 2) {
                    SelectedCustomerRefreshmentService = true;
                    SelectedCustomerRefreshmentService_Key = value.CustomerNeed_ID;
                }
                else if (value.RequestedService_ID == 3) {
                    SelectedCustomerTransportationService = true;
                    SelectedCustomerTransportationService_Key = value.CustomerNeed_ID;
                }
                else if (value.RequestedService_ID == 5) {
                    SelectedCustomerCoffeeService = true;
                    SelectedCustomerCoffeeService_Key = value.CustomerNeed_ID;
                }
            }
        });
    }
}

function CheckIfCustomerHasNeeds(Customer_ID)
{
    var HasNeeds = false;

    if (NeedsArray == null) return; // Marronazo

    if (NeedsArray != null)
    {
        $.each(NeedsArray, function (key, value)
        {
            if (value.Customer_ID == Customer_ID)
            {
                HasNeeds = true;
            }
        });
    }

    return HasNeeds;
}

function UpdateMinsWaiting(VisitDate)
{
    var startDate = moment(new Date(VisitDate));
    var endDate = moment(new Date());

    //var diff = endDate - startDate;

    //diffMins = Math.round(((diff % 86400000) % 3600000) / 60000); // minutes

    var duration = moment.duration(endDate.diff(startDate));
    diffMins = Math.round(duration.asMinutes());
}

function drawCustomersInfo(tile_size, ctx)
{
    $.each(CustomersArray, function (key, value)
    {
        var x_pos = value.Seat_X * tile_size;
        var y_pos = value.Seat_Y * tile_size;

        UpdateMinsWaiting(value.VisitDate);

        var text_x = x_pos + 8;
        var text_y = y_pos + map_top_margin;

        if (MapData[value.Seat_X][value.Seat_Y] == 1) {
            text_y += tile_size + 12;
        }

        ctx.fillStyle = "White";
        
        ctx.fillText(diffMins + " min.", text_x, text_y);

        if (value.Customer_ID == customer_ID)
        {
            SelectedCustomerTime_Mood = value.Mood;
            SelectedCustomerTime_Value = diffMins;
            SelectedCustomerTime = diffMins + " min.";
        }
    });
}

function drawScreenText(ctx)
{
    var TextIndent = 80;

    ctx.font = "16px Arial";

    ctx.fillStyle = "White";

    //ctx.fillText(" v" + SalitaVersion, 0, 980);

    if (CustomerLoadQueryState == "Loading")
    {
        ctx.fillText("Please wait...", TextIndent, 30);
    }
    else
    {
        drawDebugText(ctx, TextIndent);

        if (customerSelected)
        {
            ctx.fillText("Tiempo: " + SelectedCustomerTime, TextIndent, 30);
            ctx.fillText("Cliente: " + SelectedCustomerName, TextIndent, 50);
            ctx.fillText("Esperando por: " + SelectedCustomerWaitingFor, TextIndent, 70);

            if (SelectedCustomerWaterService == true) {
                ctx.drawImage(service_water, 250, 16, tile_Size, tile_Size);
            }

            if (SelectedCustomerRefreshmentService == true) {
                ctx.drawImage(service_can, 250 + 64, 16, tile_Size, tile_Size);
            }

            if (SelectedCustomerTransportationService == true) {
                ctx.drawImage(service_transport, 250 + (64 * 2), 16, tile_Size, tile_Size);
            }

            if (SelectedCustomerCoffeeService == true) {
                ctx.drawImage(service_cafe, 250 + (64 * 3), 16, tile_Size, tile_Size);
            }
        }

        //
        // Service Summary
        //
        Water_Count = 0;
        Coffee_Count = 0;
        Soda_Count = 0;
        Transport_Count = 0;

        if (NeedsArray != null)
        {
            $.each(NeedsArray, function (key, value)
            {
                //alert(value.RequestedService_ID);

                if (value.RequestedService_ID == 1)
                {
                    Water_Count++;
                }
                else if (value.RequestedService_ID == 5)
                {
                    Coffee_Count++;
                }
                else if (value.RequestedService_ID == 2) {
                    Soda_Count++;
                }
                else if (value.RequestedService_ID == 3 || value.RequestedService_ID == 4) {
                    Transport_Count++;
                }
            });
        }

        ctx.fillText("x " + Water_Count, 140, 950);
        ctx.fillText("x " + Coffee_Count, 295, 950);
        ctx.fillText("x " + Soda_Count, 440, 950);
        ctx.fillText("x " + Transport_Count, 595, 950);
    }

    //
    // Sticky note text
    //
    if (draw_stickynote)
    {
        ctx.drawImage(stickynote, 550, 10, 200, 223);

        ctx.fillStyle = "Black";
        ctx.font = "16px Courier New";

        //ctx.fillText(stickynote_text, 30, 110);

        var s = stickynote_text;
        var pos_x = 570;
        var pos_y = 110;
        for (var i = 0; i < s.length; i++)
        {
            ctx.fillText(s.charAt(i), pos_x, pos_y);
            
            if (pos_x >= 570 + (10 * 15))
            {
                pos_x = 570;
                pos_y += 20;
            }
            else
            {
                pos_x += 10;
            }
        }
    }

    ctx.fillStyle = "White";
}

function GetNote(Customer_ID, NoteFor)
{
    var NoteText = "N/A";

    $.each(CustomersArray, function (key, cvalue)
    {
        if (Customer_ID == cvalue.Customer_ID)
        {
            $.each(NeedsArray, function (key, nvalue)
            {
                if (nvalue.RequestedService_ID == NoteFor)
                {
                    if (NoteFor == 3)
                    {
                        NoteText = nvalue.Address_Line + " " + nvalue.Town + " " + nvalue.ZipCode;
                    }
                    else
                    {
                        NoteText = nvalue.Note;
                    }
                }
            });
        }
    });

    if (NoteText == null) NoteText = "N/A";

    return NoteText;
}

function drawDebugText(ctx, TextIndent)
{
    //ctx.fillText("Selected Tile: " + sel_tile_x + "," + sel_tile_y, 0, 880);
    //ctx.fillText(" holdDownTimer: " + holdDownTimer + ", MouseIsDown: " + MouseIsDown, 0, 900);
    //ctx.fillText(" MouseClickLogic: " + MouseClickLogic + ", doc_scroll_left: " + doc_scroll_left + ", doc_element_scroll_left: " + doc_element_scroll_left, 0, 920);
    //ctx.fillText(" SelectedTileValue: " + SelectedTileValue + ", RenderState: " + RenderState, 0, 940);
    //ctx.fillText(" customerSelected: " + customerSelected + ", index: " + customerIndex + ", target seat occuppied: " + customerInSeat, 0, 960);
}

function draw() {

    if (canvas.getContext)
    {
        var ctx = canvas.getContext('2d');

        var currentTime = Date.now();

        elapsedTime = Math.floor((currentTime - customerTime) / 1000);

        if (MouseIsDown == true) {
            holdDownTimer++;

            if (holdDownTimer > 50) {

                // Lets say mouse up is true
                MouseIsDown = false;

                holdDownTimer = 0;

                if (customerSelected == true)
                {

                    RenderState = "PopUpServices";
                }

                //Deselect the customer after popup
                customerSelected = false;
            }
        }

        ctx.drawImage(bg01, 0, 0, 768, 995);

        drawMap(tile_Size, ctx);

        if (CustomersArray != null)
        {
            drawCustomers(tile_Size, ctx);
        }

        // Draw Update Panel
        if (SelectedCustomerTime_Mood == "G")
        {
            ctx.drawImage(customer_neutral, 10, 10, 64, 64);
        }
        else if (SelectedCustomerTime_Mood == "N")
        {
            ctx.drawImage(customer_medium, 10, 10, 64, 64);
        }
        else
        {
            ctx.drawImage(customer_bad, 10, 10, 64, 64);
        }
        
        //
        // Draw Summary at Bottom
        //
        ctx.drawImage(service_water, 80, 910, 64, 64);
        ctx.drawImage(service_cafe, 230, 910, 64, 64);
        ctx.drawImage(service_can, 380, 910, 64, 64);
        ctx.drawImage(service_transport, 530, 910, 64, 64);

        drawScreenText(ctx);

        if (CustomersArray != null)
        {
            drawCustomersInfo(tile_Size, ctx);
        }

        if (RenderState == "PopUpServices")
        {

            pop_x = (canvas.width / 2) - (367 / 2);

            pop_y = (canvas.height / 2) - (367 / 2) - (367 / 4);

            ctx.drawImage(pop_up_bk, pop_x, pop_y, 367, 367);

            if (SelectedCustomerWaterService == true)
            {
                btn_water_x = pop_x + 34;
                btn_water_y = pop_y + 250;
                ctx.drawImage(pop_up_water, btn_water_x, btn_water_y, 58, 58);
            }
            else {
                btn_water_x = pop_x + 34;
                btn_water_y = pop_y + 140;
                ctx.drawImage(pop_up_water, btn_water_x, btn_water_y, 58, 58);
            }

            if (SelectedCustomerRefreshmentService == true)
            {
                btn_soda_x = pop_x + 34 + 80 + 80;
                btn_soda_y = pop_y + 250;
                ctx.drawImage(pop_up_soda, btn_soda_x, btn_soda_y, 58, 58);
            }
            else {
                btn_soda_x = pop_x + 34 + 80 + 80;
                btn_soda_y = pop_y + 140;
                ctx.drawImage(pop_up_soda, btn_soda_x, btn_soda_y, 58, 58);
            }

            if (SelectedCustomerTransportationService == true) {
                btn_taxi_x = pop_x + 34 + 80 + 80 + 80;
                btn_taxi_y = pop_y + 250;
                ctx.drawImage(pop_up_taxi, btn_taxi_x, btn_taxi_y, 58, 58);
            }
            else {

                btn_taxi_x = pop_x + 34 + 80 + 80 + 80;
                btn_taxi_y = pop_y + 140;
                ctx.drawImage(pop_up_taxi, btn_taxi_x, btn_taxi_y, 58, 58);
            }

            if (SelectedCustomerCoffeeService == true) {
                btn_cafe_x = pop_x + 34 + 80;
                btn_cafe_y = pop_y + 250;
                ctx.drawImage(pop_up_cafe, btn_cafe_x, btn_cafe_y, 58, 58);
            }
            else {

                btn_cafe_x = pop_x + 34 + 80;
                btn_cafe_y = pop_y + 140;
                ctx.drawImage(pop_up_cafe, btn_cafe_x, btn_cafe_y, 58, 58);
            }

            // Draw Mood Selection Faces
            btn_change_mood_x = btn_water_x;
            btn_change_mood_x2 = btn_cafe_x;
            btn_change_mood_x3 = btn_soda_x;
            btn_change_mood_y = 260;

            ctx.drawImage(customer_neutral, btn_change_mood_x, btn_change_mood_y, 48, 48);
            ctx.drawImage(customer_medium, btn_change_mood_x2, btn_change_mood_y, 48, 48);
            ctx.drawImage(customer_bad, btn_change_mood_x3, btn_change_mood_y, 48, 48);
        }

        ctx.stroke();

        window.requestAnimationFrame(draw);
    }
}

function IsACustomerInTargetSeat(dest_tile_x, dest_tile_y) {
    var ReturnValue = false;

    $.each(CustomersArray, function (key, value) {
        if (dest_tile_x == value.Seat_X && dest_tile_y == value.Seat_Y) {
            ReturnValue = true;
        }
    });

    return ReturnValue;
}

function GetTileValue(column, row) {
    return MapData[row][column];
}

function doMouseUp(event) {

    MouseIsDown = false;

    holdDownTimer = 0;
}

function PlayClick()
{
    if (sndClick.readyState > 0) {
        sndClick.currentTime = 0;
        sndClick.play();
    }
}

function doMouseDown(event)
{

    draw_stickynote = false;

    MouseIsDown = true;

    if (true)
    {
        //
        // Get the selected tile
        //

        doc_scroll_left = document.body.scrollLeft;
        doc_element_scroll_left = document.documentElement.scrollLeft;

        if (event.x != undefined && event.y != undefined) {

            mouse_x = event.x - doc_scroll_left +
                doc_element_scroll_left;

            mouse_y = event.y + document.body.scrollTop +
                document.documentElement.scrollTop;

            MouseClickLogic = "Explorer";
        }
        else // Firefox method to get the position
        {
            mouse_x = event.clientX + doc_scroll_left +
                doc_element_scroll_left;

            mouse_y = event.clientY + document.body.scrollTop +
                document.documentElement.scrollTop;

            MouseClickLogic = "Firefox";
        }

        mouse_x -= (canvas.offsetLeft);
        mouse_y -= (canvas.offsetTop) + map_top_margin;


        //
        // Items with Notes
        //

        if (mouse_x > 250 && mouse_x < (250 + tile_Size) && mouse_y > (16 - map_top_margin) && mouse_y < (16 - map_top_margin) + tile_Size)
        {
            if (SelectedCustomerWaterService == true)
            {
                draw_stickynote = true;
                stickynote_text = GetNote(customer_ID, 1);
            }
        }
        else if (mouse_x > 250 + 64 && mouse_x < (250 + 64 + tile_Size) && mouse_y > (16 - map_top_margin) && mouse_y < (16 - map_top_margin) + tile_Size)
        {
            if (SelectedCustomerRefreshmentService == true)
            {
                draw_stickynote = true;
                stickynote_text = GetNote(customer_ID, 2);
            }
        }
        else if (mouse_x > 250 + (64 * 2) && mouse_x < (250 + (64 * 2) + tile_Size) && mouse_y > (16 - map_top_margin) && mouse_y < (16 - map_top_margin) + tile_Size)
        {
            if (SelectedCustomerTransportationService == true)
            {
                draw_stickynote = true;
                stickynote_text = GetNote(customer_ID, 3);
            }
        }
        else if (mouse_x > 250 + (64 * 3) && mouse_x < (250 + (64 * 3) + tile_Size) && mouse_y > (16 - map_top_margin) && mouse_y < (16 - map_top_margin) + tile_Size)
        {
            if (SelectedCustomerCoffeeService == true)
            {
                draw_stickynote = true;
                stickynote_text = GetNote(customer_ID, 5);
            }
        }
        else if (mouse_x > 10 && mouse_x < (10 + tile_Size) && mouse_y > (10 - map_top_margin) && mouse_y < (10 - map_top_margin) + tile_Size)
        {
            draw_stickynote = true;
            //stickynote_text = GetNote(customer_ID, 5);
        }

        sel_tile_x = Math.floor(mouse_x / tile_Size);
        sel_tile_y = Math.floor(mouse_y / tile_Size);

        if (sel_tile_x >= 0 && sel_tile_x < map_columns && sel_tile_y >= 0 && sel_tile_y < map_rows)
        {
            SelectedTileValue = GetTileValue(sel_tile_x, sel_tile_y);

            if (RenderState == "Salita")
            {

                // If it is a seat
                if (SelectedTileValue >= 1 && SelectedTileValue <= chairs_tiles_max)
                {
                    customerInSeat = false;
                    if (customerSelected == true && (sel_tile_x != old_sel_tile_x || sel_tile_y != old_sel_tile_y)) {
                        if (IsACustomerInTargetSeat(sel_tile_x, sel_tile_y) == false) {

                            CustomersArray[customerIndex].Seat_X = sel_tile_x;
                            CustomersArray[customerIndex].Seat_Y = sel_tile_y;

                            UpdateQueryState = "Loading";
                            callAjaxMethod("POST", 'default.aspx/ChangeSeat', '{Customer_ID: "' + customer_ID + '", Seat_X: ' + sel_tile_x + ', Seat_Y: ' + sel_tile_y + ' }', 0);

                            //Deselect the customer after seating
                            customerSelected = false;

                            return;
                        }
                        else {
                            customerInSeat = true;
                        }
                    }
                }
                else if (SelectedTileValue == 9)
                {
                    // Exit salita
                    UpdateQueryState = "Loading";
                    callAjaxMethod("POST", 'default.aspx/LeaveLounge', '{Customer_ID: "' + customer_ID + '" }', 0);

                    //Deselect the customer after seating
                    customerSelected = false;

                    return;
                }

                //
                // Selection logic
                //
                Water_Count = 0;

                if (CustomersArray != null)
                {
                    cIndex = -1; // None selected
                    customerSelected = false;
                    $.each(CustomersArray, function (key, value)
                    {
                        cIndex++;

                        if (sel_tile_x == value.Seat_X && sel_tile_y == value.Seat_Y)
                        {
                            // Customer was selected
                            customerIndex = cIndex;
                            customerSelected = true;
                            customer_ID = value.Customer_ID;
                            SelectedCustomerName = value.FullName;
                            SelectedCustomerWaitingFor = value.WaitingFor;

                            CheckCustomerNeeds(customer_ID);

                            if (sndClick.readyState > 0)
                            {
                                sndClick.currentTime = 0;
                                sndClick.play();
                            }

                        }
                    });
                }
            }
            else if (RenderState == "PopUpServices")
            {
                if (!(mouse_x > pop_x && mouse_x < pop_x + 367 && mouse_y > (pop_y - map_top_margin) && mouse_y < (pop_y - map_top_margin) + 367))
                {
                    RenderState = "Salita";
                }
                else if (mouse_x > 510 && mouse_y > 240 - map_top_margin && mouse_x < (510 + 40) && mouse_y < (240 + 40) - map_top_margin)
                {
                    RenderState = "Salita";
                }
                else
                {

                    if (mouse_x > btn_water_x && mouse_x < btn_water_x + 58 && mouse_y > btn_water_y - map_top_margin && mouse_y < btn_water_y - map_top_margin + 58)
                    {
                        Selected_Icon = "Water";

                        PlayClick();

                        if (btn_water_y < 470)
                        {
                            SelectedCustomerRefreshmentService_Key = 1;
                            dialog.dialog("open");
                            RenderState = "Salita";
                        }
                        else
                        {
                            dialog_Fulfill.dialog("open");
                            RenderState = "Salita";
                        }
                    }
                    else if (mouse_x > btn_soda_x && mouse_x < btn_soda_x + 58 && mouse_y > btn_soda_y - map_top_margin && mouse_y < btn_soda_y - map_top_margin + 58)
                    {
                        Selected_Icon = "Soda";

                        PlayClick();

                        if (btn_soda_y < 470)
                        {
                            SelectedCustomerRefreshmentService_Key = 2;
                            dialog.dialog("open");
                            RenderState = "Salita";
                        }
                        else
                        {
                            dialog_Fulfill.dialog("open");
                            RenderState = "Salita";
                        };               
                    }
                    else if (mouse_x > btn_cafe_x && mouse_x < btn_cafe_x + 58 && mouse_y > btn_cafe_y - map_top_margin && mouse_y < btn_cafe_y - map_top_margin + 58)
                    {
                        Selected_Icon = "Coffee";

                        PlayClick();

                        if (btn_cafe_y < 470)
                        {
                            SelectedCustomerRefreshmentService_Key = 5;
                            dialog.dialog("open");
                            RenderState = "Salita";
                        }
                        else
                        {
                            dialog_Fulfill.dialog("open");
                            RenderState = "Salita";
                        };
                    }
                    else if (mouse_x > btn_taxi_x && mouse_x < btn_taxi_x + 58 && mouse_y > (btn_taxi_y - map_top_margin) && mouse_y < (btn_taxi_y - map_top_margin) + 58)
                    {
                        Selected_Icon = "Transportation";

                        PlayClick();

                        if (btn_taxi_y < 470) {
                            window.location.assign("address.aspx?id=" + customer_ID + "&name=" + SelectedCustomerName);
                        }
                        else
                        {
                            window.location.assign("service_complete.aspx?id=" + SelectedCustomerTransportationService_Key);
                        }
                    }
                    else if (mouse_x > btn_change_mood_x && mouse_x < btn_change_mood_x + 48 && mouse_y > (btn_change_mood_y - map_top_margin) && mouse_y < (btn_change_mood_y - map_top_margin) + 48)
                    {
                        window.location.assign("change_mood.aspx?id=" + customer_ID + "&m=1");
                    }
                    else if (mouse_x > btn_change_mood_x2 && mouse_x < btn_change_mood_x2 + 48 && mouse_y > (btn_change_mood_y - map_top_margin) && mouse_y < (btn_change_mood_y - map_top_margin) + 48) {
                        window.location.assign("change_mood.aspx?id=" + customer_ID + "&m=2");
                    }
                    else if (mouse_x > btn_change_mood_x3 && mouse_x < btn_change_mood_x3 + 48 && mouse_y > (btn_change_mood_y - map_top_margin) && mouse_y < (btn_change_mood_y - map_top_margin) + 48) {
                        window.location.assign("change_mood.aspx?id=" + customer_ID + "&m=3");
                    }
                }
            }

            //
            // Store the previously selected tile
            //
            old_sel_tile_x = sel_tile_x;
            old_sel_tile_y = sel_tile_y;
        }
    }
}