<script type="text/javascript">
    function checkRadioBtn(id, c) {
        var gv = document.getElementById('ContentPlaceHolder1_GridView1');

        for (var i = 1; i < gv.rows.length; i++) {
            var radioBtn = gv.rows[i].cells[c].getElementsByTagName("input");

            // Check if the id not same
            if (radioBtn[0].id != id.id) {
                radioBtn[0].checked = false;
            }
        }
    }
</script>