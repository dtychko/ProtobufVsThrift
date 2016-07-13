function measure(fn, message) {
    let time = process.hrtime();
    const result = fn();
    time = process.hrtime(time);
    console.log(message, format(time));
    return result;
}

function format(time) {
    var s = time[0];
    var ns = time[1];
    return `${1000 * s + Math.ceil(ns / 1000) / 1000} ms`;
}

module.exports.measure = measure;
