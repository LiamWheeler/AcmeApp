/*
	Checks if a shop is open from the time of day and the day of the week.
*/
function someTime(time, day) {
    if (day === "Sunday" && time > 8 && time < 18){
    return "shop is open"
    }
    else if (day === "Saturday" && time > 8 && time < 18) {
    return "shop is open"
    } 
    else if (time > 6 && time < 20 && day === !"Sunday" && day === !"Saturday") {
    return "shop is open"
    } else {
    return "shop is closed"
    }
}

    
    
console.log(someTime(14, "Sunday"));

/*
	check whether the shop is open at a particular time
	returns the open / closed status of the shop

*/
function getShopStatus(time, day) {
	if(day === "Sunday" || day === "Saturday") {
		return checkWeekendTimes(time)
	} else {
		return checkWeekdayTimes(time)
	}
}

function checkWeekendTimes(time) {
	if(time > 8 && time < 18) {
		return "shop is open"
	} else {
		return "shop is closed"
	}
}

function checkWeekdayTimes(time) {
	if(time > 7 && time < 20) {
		return "shop is open"
	} else {
		return "shop is closed"
	}
}

console.log(getShopStatus(12,"Saturday"))