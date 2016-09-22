cmake_minimum_required(VERSION 3.5)

project(test_rclcs)

find_package(ament_cmake REQUIRED)
find_package(builtin_interfaces REQUIRED)
find_package(rosidl_default_generators REQUIRED)

if(BUILD_TESTING)
 find_package(ament_lint_auto REQUIRED)
 ament_lint_auto_find_test_dependencies()

   add_custom_target(test_rclcs_dll ALL
	COMMAND 
	xbuild test_rclcs.csproj /property:OutputPath="${CMAKE_BINARY_DIR}"
	WORKING_DIRECTORY
	${CMAKE_SOURCE_DIR}/src
   )
   

  # add_custom_target(run_test_rclcs ALL
#	COMMAND 
#	mono ${CMAKE_CURRENT_SOURCE_DIR}/src/nunit/bin/nunit3-console.exe ${CMAKE_BINARY_DIR}/test_rclcs.dll /property:OutputPath="${CMAKE_BINARY_DIR}"
#	WORKING_DIRECTORY
#	${CMAKE_SOURCE_DIR}/src
  # )
 #  add_dependencies(run_test_rclcs test_rclcs_dll)
  

endif(BUILD_TESTING)
ament_package()
