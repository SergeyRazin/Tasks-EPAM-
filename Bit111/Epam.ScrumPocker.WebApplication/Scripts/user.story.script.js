var roomId;

var startEstimating = function () {
	$.ajax({
		url: '/Room/StartEstimating',
		type: "POST",
		data: { id: roomId },
		success: function () {
		    $("#StartVoting")
                .attr("id", "StopEstimating")
                .attr("onClick", "stopEstimating()")
		        .text("Stop Estimating");
		}
	})
};

var stopEstimating = function () {
    $.ajax({
        url: '/Room/StopEstimating',
        type: "POST",
        data: { id: roomId },
        success: function () {
            $("#StopEstimating").attr("disabled", "disabled");
        }
    })
};


$(document).ready(function () {
	$("#UserStoryForm").submit(function (e) {
	    e.preventDefault();

		var name = $("#UserStoryName").val();
		var description = $("#UserStoryDescription").val();

		$.ajax({
			url: '/Create',
			type: "POST",
			dataType: "json",
			data: { Name: name, Description: description },
			success: function (data) {
				roomId = data.id;
				var estimatingUrl = "http://" + window.location.host + "/" + roomId;
				var roomInfo = $('<div />').attr("id", "StoryDescription");
				roomInfo.append($('<h3 />').text(name));
				roomInfo.append($('<p />').text(description));
				roomInfo.append($('<input />').attr({
					type: "text",
					value: estimatingUrl,
					class: "form-control",
					id: "EstimatingLink",
					onclick: "this.select()"
				}));
				roomInfo.append($('<button />').attr({
					id: "StartVoting",
					class: "btn btn-default",
					onclick: "startEstimating()",
				}).text("Start Estimating"));

				$("h2").remove();
				$("form").replaceWith(roomInfo);
			}
		})
	});
});