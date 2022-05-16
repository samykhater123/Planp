// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    $(document).ready(function () {

            $('#dll').change(function () {


                var prog = $('#dll').val();
                //$('#mony').val(prog)
                $.ajax({

                    url: "../Players/getmonyvalueAsync",
                    data: prog,
                    method: "GET",
                    async: true,
                    success: function (result) {
                        alert("csdcds");
                        result = JSON.parse(result);
                        console.log(result);
                        $('#mony').val(result);

                    }

                });
            

            });
    })
    