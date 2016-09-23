cmake_minimum_required(VERSION 3.5)

project(test_rclcs)

find_package(ament_cmake REQUIRED)
find_package(builtin_interfaces REQUIRED)
find_package(rosidl_default_generators REQUIRED)

if(BUILD_TESTING)
 find_package(ament_lint_auto REQUIRED)
 ament_lint_auto_find_test_dependencies()

 if(NOT WIN32)
   add_custom_target(test_rclcs_dll ALL
	COMMAND 
	xbuild test_rclcs.csproj /property:OutputPath="${CMAKE_BINARY_DIR}"
	WORKING_DIRECTORY
	${CMAKE_SOURCE_DIR}/src
   )
   
   set(ENV{MONO_PATH} $ENV{AMENT_PREFIX_PATH}/lib)
   install(FILES ${CMAKE_BINARY_DIR}/test_rclcs.dll DESTINATION lib)
   install(FILES ${CMAKE_BINARY_DIR}/nunit.framework.dll DESTINATION lib)
   
  install(CODE "set(PROJECT_DIR_PATH \"${CMAKE_SOURCE_DIR}\")")
  install(SCRIPT "${CMAKE_SOURCE_DIR}/PostInstall.cmake")
  endif()

endif(BUILD_TESTING)
ament_package()
