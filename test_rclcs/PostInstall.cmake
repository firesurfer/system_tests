execute_process(
	COMMAND 
	mono ${PROJECT_DIR_PATH}/src/nunit/bin/nunit3-console.exe $ENV{AMENT_PREFIX_PATH}/lib/test_rclcs.dll --framework:mono-4.5 --labels=All
	WORKING_DIRECTORY
	$ENV{AMENT_PREFIX_PATH}/lib
        RESULT_VARIABLE rv
        OUTPUT_VARIABLE ov
        ERROR_VARIABLE ev
   )
#Display the results
message("rv='${rv}'")
message("ov='${ov}'")
message("ev='${ev}'")
