/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var gulpExec = require('gulp-exec');
var gulpPipe = require('gulp-pipe');
var childProcess = require('child_process').exec;

gulp.task('ngBuild', function (cb) {
    console.log("Start task");
    //console.log(__dirname);

    // ping localhost works
    // echo %cd% works
    // ng build does not work
    childProcess('ng build --aot', function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        cb(err);
    });

    console.log("End task");
});