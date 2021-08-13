#!/usr/bin/ruby

def pretty_print(text)
  puts "== #{text}"
end

PROJECT_DIR = "."
OUTPUT_DIR = "./builds/WebGL/LoveCubed";

BUILD_COMMAND = "/Applications/Unity/2020.3.3f1/Unity.app/Contents/MacOS/Unity -batchmode -projectPath #{PROJECT_DIR} -executeMethod WebGLBuilder.Build -quit -logFile build.log"
BUTLER_COMMAND ="butler push #{OUTPUT_DIR} wizards-of-iga/love-cubed:html5"

pretty_print "Building for WebGL"
pretty_print "Running Command => #{BUILD_COMMAND}"

puts `#{BUILD_COMMAND}`

pretty_print "Uploading build to itch"
pretty_print "Runnign Command => #{BUTLER_COMMAND}"

puts `#{BUTLER_COMMAND}`

pretty_print "Done"
