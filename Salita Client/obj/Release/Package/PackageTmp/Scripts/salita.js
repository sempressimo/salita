//
// Variables
//
var SalitaVersion = "Beta 0.8.1";

//
// Images
//
var floor1 = new Image();
var customer_neutral = new Image();
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
var pop_up_bk = new Image();
var pop_up_cafe = new Image();
var pop_up_water = new Image();
var pop_up_soda = new Image();
var pop_up_taxi = new Image();

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

//
// Sounds
//
var sndClick = new Audio();

//
// Mouse Control
//
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
var SelectedCustomerWaitingFor = "N/A";
var SelectedTileValue = new Number();

var SelectedCustomerWaterService = false;
var SelectedCustomerRefreshmentService = false;
var SelectedCustomerCoffeeService = false;
var SelectedCustomerTransportationService = false;

var customerTime = Date.now();
var RenderState = "Salita";

var alert_blink = 0;

//
// Debug Vars
//
var elapsedTime = 0;
var elapsedTimeSinceRefresh = 0;
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
var MapData =
    [
        [0, 8, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 4, 0, 0, 0, 3, 0, 0, 0],
        [0, 0, 0, 0, 4, 0, 0, 0, 3, 0, 0, 0],
        [0, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0],
        [0, 0, 0, 0, 3, 0, 0, 4, 0, 0, 0, 0],
        [0, 0, 0, 0, 3, 0, 0, 4, 0, 0, 0, 0],
        [0, 2, 2, 2, 0, 0, 0, 4, 0, 0, 0, 0],
        [0, 1, 1, 1, 0, 0, 0, 4, 0, 0, 0, 0],
        [0, 0, 0, 0, 3, 0, 0, 0, 2, 2, 0, 5],
        [0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0],
        [0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 6]
    ];

//var global_uri = "http://localhost:8395/api/visit";
var global_uri = "http://loungewebapi.azurewebsites.net/api/visit";

//var global_uri_needs = "http://localhost:8395/api/CustomerNeed";
var global_uri_needs = "http://loungewebapi.azurewebsites.net/api/CustomerNeed";

//
// Functions
//
function sendJSonRequest(uri, Array_to_update) {

    $.ajax({ type: "GET", url: uri })
        .done(function (data) {
            if (Array_to_update == "Visits") {
                CustomersArray = data;
            }
            else if (Array_to_update == "Needs") {
                NeedsArray = data;
            }
            CustomerLoadQueryState = "Finished"
        })
        .error(function (jqXHR, textStatus, errorThrown) {
            alert("sendJSonRequest(" + uri + "): textStatus: " + textStatus);
        });
}

function init() {

    CustomerLoadQueryState = "Loading";

    // Load Images
    bg01.src = "images/bg01.png";

    //floor1.src = 'images/floor0.png';

    // Initialise the collision sound
    //sndClick = document.getElementById("clicksound");
    sndClick.src = "sounds/click.wav";

    customer_neutral.src = "images/customer_neutral.png";
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
    pop_up_bk.src = "images/pop_back.png";
    pop_up_cafe.src = "images/pop_cafe.png";
    pop_up_water.src = "images/pop_water.png";
    pop_up_soda.src = "images/pop_soda.png";
    pop_up_taxi.src = "images/pop_taxi.png";

    canvas = document.getElementById('salitacanvas');

    canvas.addEventListener("mousedown", doMouseDown, false);

    canvas.addEventListener("mouseup", doMouseUp, false);

    canvas.addEventListener("touchstart", doMouseDown, false);

    canvas.addEventListener("touchend", doMouseUp, false);


    UpdateJsonArrays();

    window.requestAnimationFrame(draw);
}

function UpdateJsonArrays() {
    sendJSonRequest(global_uri, "Visits");
    sendJSonRequest(global_uri_needs, "Needs");
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

            index++;
        }
    }
}

function drawCustomers(tile_size, ctx) {
    alert_blink += 1;

    CustomersCount = 0;

    $.each(CustomersArray, function (key, value) {

        var x_pos = value.Seat_X * tile_size;
        var y_pos = value.Seat_Y * tile_size;

        if (customerSelected == true && customer_ID == value.Customer_ID) {
            ctx.drawImage(customer_selected, x_pos, y_pos + map_top_margin, tile_size, tile_size);
        }
        else {
            ctx.drawImage(customer_neutral, x_pos, y_pos + map_top_margin, tile_size, tile_size);
        }

        if (CheckIfCustomerHasNeeds(value.Customer_ID)) {
            if (alert_blink >= 30) {
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

function CheckCustomerNeeds(Customer_ID) {

    SelectedCustomerWaterService = false;
    SelectedCustomerRefreshmentService = false;
    SelectedCustomerTransportationService = false;
    SelectedCustomerCoffeeService = false;

    $.each(NeedsArray, function (key, value) {
        if (value.Customer_ID == Customer_ID) {
            if (value.RequestedService_ID == 1) {
                SelectedCustomerWaterService = true;
            }
            else if (value.RequestedService_ID == 2) {
                SelectedCustomerRefreshmentService = true;
            }
            else if (value.RequestedService_ID == 3) {
                SelectedCustomerTransportationService = true;
            }
            else if (value.RequestedService_ID == 5) {
                SelectedCustomerCoffeeService = true;
            }
        }
    });
}

function CheckIfCustomerHasNeeds(Customer_ID) {
    var HasNeeds = false;

    $.each(NeedsArray, function (key, value) {
        if (value.Customer_ID == Customer_ID) {
            HasNeeds = true;
        }
    });

    return HasNeeds;
}

function drawCustomersInfo(tile_size, ctx) {
    $.each(CustomersArray, function (key, value) {

        var x_pos = value.Seat_X * tile_size;
        var y_pos = value.Seat_Y * tile_size;

        var startDate = new Date(value.VisitDate);
        var endDate = new Date();

        var diff = endDate - startDate;
        var diff_as_date = new Date(diff);

        var text_x = x_pos + 8;
        var text_y = y_pos + map_top_margin;

        if (MapData[value.Seat_X][value.Seat_Y] == 1) {
            text_y += tile_size + 12;
        }

        ctx.fillStyle = "White";
        ctx.fillText(diff_as_date.getMinutes() + " min.", text_x, text_y);
        //ctx.fillText(value.FullName, text_x, text_y);

        if (value.Customer_ID == customer_ID) {
            SelectedCustomerTime = diff_as_date.getMinutes() + " min.";
        }
    });
}

function drawScreenText(ctx) {

    var TextIndent = 80;

    ctx.font = "16px Arial";

    ctx.fillStyle = "White";

    ctx.fillText(" Version: " + SalitaVersion, 0, 980);

    if (CustomerLoadQueryState == "Loading") {
        ctx.fillText("Loading...", TextIndent, 30);
    }
    else {
        drawDebugText(ctx, TextIndent);

        if (customerSelected) {
            ctx.fillText("Tiempo: " + SelectedCustomerTime, TextIndent, 30);
            ctx.fillText("Cliente: " + SelectedCustomerName, TextIndent, 50);
            ctx.fillText("Esperando por: " + SelectedCustomerWaitingFor, TextIndent, 70);

            if (SelectedCustomerWaterService == true) {
                ctx.drawImage(service_water, 250, 16, tile_Size, tile_Size);
            }

            if (SelectedCustomerRefreshmentService == true) {
                //ctx.drawImage(alert_img, 250 + 64, tile_Size, tile_Size);
            }

            if (SelectedCustomerTransportationService == true) {
                ctx.drawImage(service_transport, 250 + (64 * 2), 16, tile_Size, tile_Size);
            }

            if (SelectedCustomerCoffeeService == true) {
                ctx.drawImage(service_cafe, 250 + (64 * 3), 16, tile_Size, tile_Size);
            }
        }
    }
}

function drawDebugText(ctx, TextIndent) {
    //ctx.fillText("Selected Tile: " + sel_tile_x + "," + sel_tile_y, 0, 880);
    ctx.fillText(" holdDownTimer: " + holdDownTimer + ", MouseIsDown: " + MouseIsDown, 0, 900);
    //ctx.fillText("elapsedTime: " + elapsedTime + ", elapsedTimeSinceRefresh: " + elapsedTimeSinceRefresh, 0, 50);
    ctx.fillText(" MouseClickLogic: " + MouseClickLogic + ", doc_scroll_left: " + doc_scroll_left + ", doc_element_scroll_left: " + doc_element_scroll_left, 0, 920);
    ctx.fillText(" SelectedTileValue: " + SelectedTileValue + ", RenderState: " + RenderState, 0, 940);
    ctx.fillText(" customerSelected: " + customerSelected + ", index: " + customerIndex + ", target seat occuppied: " + customerInSeat, 0, 960);
}

function draw() {
    if (elapsedTimeSinceRefresh > 500) {

        if (UpdateQueryState == "Finished") {
            UpdateJsonArrays();
        }

        elapsedTimeSinceRefresh = 0;
    }

    if (canvas.getContext) {
        var ctx = canvas.getContext('2d');

        var currentTime = Date.now();

        elapsedTime = Math.floor((currentTime - customerTime) / 1000);

        elapsedTimeSinceRefresh = elapsedTimeSinceRefresh + 1;

        if (MouseIsDown == true) {
            holdDownTimer++;

            if (holdDownTimer > 50) {

                // Lets say mouse up is true
                MouseIsDown = false;

                holdDownTimer = 0;

                if (customerSelected == true) {
                    //UpdateQueryState = "Loading";
                    //callAjaxMethod(event, 'default.aspx/SetSelectedCustomer', '{Customer_ID: "' + customer_ID + '" }', 1);

                    RenderState = "PopUpServices";
                }

                //Deselect the customer after double click
                customerSelected = false;
            }
        }

        ctx.drawImage(bg01, 0, 0, 768, 995);

        drawMap(tile_Size, ctx);

        if (CustomersArray != null) {
            drawCustomers(tile_Size, ctx);
        }

        // Draw Update Panel
        ctx.drawImage(customer_neutral, 10, 10, 64, 64);

        drawScreenText(ctx);

        if (CustomersArray != null) {
            drawCustomersInfo(tile_Size, ctx);
        }

        if (RenderState == "PopUpServices") {

            pop_x = (canvas.width / 2) - (367 / 2);

            pop_y = (canvas.height / 2) - (367 / 2) - (367 / 4);

            ctx.drawImage(pop_up_bk, pop_x, pop_y, 367, 367);

            btn_water_x = pop_x + 34;
            btn_water_y = pop_y + 140;
            ctx.drawImage(pop_up_water, btn_water_x, btn_water_y, 58, 58);

            btn_cafe_x = pop_x + 34 + 80;
            btn_cafe_y = pop_y + 140;
            ctx.drawImage(pop_up_cafe, btn_cafe_x, btn_cafe_y, 58, 58);

            btn_soda_x = pop_x + 34 + 80 + 80;
            btn_soda_y = pop_y + 140;
            ctx.drawImage(pop_up_soda, btn_soda_x, btn_cafe_y, 58, 58);

            btn_taxi_x = pop_x + 34 + 80 + 80 + 80;
            btn_taxi_y = pop_y + 140;
            ctx.drawImage(pop_up_taxi, btn_taxi_x, btn_taxi_y, 58, 58);
        }

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

function callAjaxMethod(e, _url, _parameters, popup_id) {

    //To prevent postback from happening as we are ASP.Net TextBox control

    //If we had used input html element, there is no need to use ' e.preventDefault()' as posback will not happen

    //e.preventDefault();

    $.ajax({
        type: "POST",
        url: _url,
        data: _parameters,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            UpdateQueryState = "Finished";

            if (popup_id == 1) {
                btn_water_y = 400;
            }
        },
        failure: function (response) {
            alert("Error in calling Ajax:" + response.d);
        }
    });
}

function GetTileValue(column, row) {
    return MapData[row][column];
}

function doMouseUp(event) {

    MouseIsDown = false;

    holdDownTimer = 0;
}

var MouseIsDown = false;
function doMouseDown(event) {

    MouseIsDown = true;

    if (true) {
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

        sel_tile_x = Math.floor(mouse_x / tile_Size);
        sel_tile_y = Math.floor(mouse_y / tile_Size);

        if (sel_tile_x >= 0 && sel_tile_x < map_columns && sel_tile_y >= 0 && sel_tile_y < map_rows) {
            SelectedTileValue = GetTileValue(sel_tile_x, sel_tile_y);

            if (RenderState == "Salita")
            {
                // If it is a seat
                if (SelectedTileValue >= 1 && SelectedTileValue <= chairs_tiles_max) {
                    customerInSeat = false;
                    if (customerSelected == true && (sel_tile_x != old_sel_tile_x || sel_tile_y != old_sel_tile_y)) {
                        if (IsACustomerInTargetSeat(sel_tile_x, sel_tile_y) == false) {

                            CustomersArray[customerIndex].Seat_X = sel_tile_x;
                            CustomersArray[customerIndex].Seat_Y = sel_tile_y;

                            UpdateQueryState = "Loading";
                            callAjaxMethod(event, 'default.aspx/ChangeSeat', '{Customer_ID: "' + customer_ID + '", Seat_X: ' + sel_tile_x + ', Seat_Y: ' + sel_tile_y + ' }', 0);

                            //Deselect the customer after seating
                            customerSelected = false;

                            return;
                        }
                        else {
                            customerInSeat = true;
                        }
                    }
                }

                //
                // Selection logic
                //
                if (CustomersArray != null) {
                    cIndex = -1; // None selected
                    customerSelected = false;
                    $.each(CustomersArray, function (key, value) {
                        cIndex++;
                        if (sel_tile_x == value.Seat_X && sel_tile_y == value.Seat_Y) {
                            // Customer was selected
                            customerIndex = cIndex;
                            customerSelected = true;
                            customer_ID = value.Customer_ID;
                            SelectedCustomerName = value.FullName;
                            SelectedCustomerWaitingFor = value.WaitingFor;

                            CheckCustomerNeeds(customer_ID);

                            if (sndClick.readyState > 0) {
                                sndClick.currentTime = 0;
                                sndClick.play();
                            }

                        }
                    });
                }
            }
            else if (RenderState == "PopUpServices")
            {
                if (!(mouse_x > pop_x && mouse_x < pop_x + 367 && mouse_y > (pop_y - map_top_margin) && mouse_y < (pop_y - map_top_margin) + 367)) {
                    RenderState = "Salita";
                }
                else
                {

                    if (mouse_x > btn_water_x && mouse_x < btn_water_x + 58 && mouse_y > btn_water_y - map_top_margin && mouse_y < btn_water_y - map_top_margin + 58)
                    {
                        if (sndClick.readyState > 0) {
                            sndClick.currentTime = 0;
                            sndClick.play();
                        }

                        callAjaxMethod(event, 'default.aspx/ProcessService', '{Customer_ID: "' + customer_ID + '", Service_ID: 1 }', 1);
                    }
                    else if (mouse_x > btn_soda_x && mouse_x < btn_soda_x + 58 && mouse_y > btn_soda_y - map_top_margin && mouse_y < btn_soda_y - map_top_margin + 58) {
                        if (sndClick.readyState > 0) {
                            sndClick.currentTime = 0;
                            sndClick.play();
                        }

                        callAjaxMethod(event, 'default.aspx/ProcessService', '{Customer_ID: "' + customer_ID + '", Service_ID: 2 }', 1);
                    }
                    else if (mouse_x > btn_cafe_x && mouse_x < btn_cafe_x + 58 && mouse_y > btn_cafe_y - map_top_margin && mouse_y < btn_cafe_y - map_top_margin + 58) {
                        if (sndClick.readyState > 0) {
                            sndClick.currentTime = 0;
                            sndClick.play();
                        }

                        callAjaxMethod(event, 'default.aspx/ProcessService', '{Customer_ID: "' + customer_ID + '", Service_ID: 5 }', 1);
                    }
                    else if (mouse_x > btn_taxi_x && mouse_x < btn_taxi_x + 58 && mouse_y > (btn_taxi_y - map_top_margin) && mouse_y < (btn_taxi_y - map_top_margin) + 58)
                    {
                        if (sndClick.readyState > 0) {
                            sndClick.currentTime = 0;
                            sndClick.play();
                        }

                        window.location.assign("address.aspx?id=" + customer_ID);
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