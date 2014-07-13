$(function () {
	setInterval(function () {
		$.ajax({
			url: '/Voting/Results' + window.location.pathname,
			dataType: 'html',
			success: function (data) {
				$('#partial').html(data);
			}
		});
	}, 2000);
});