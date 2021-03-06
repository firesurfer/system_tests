// Copyright 2015 Open Source Robotics Foundation, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#include <chrono>
#include <iostream>
#include <memory>
#include <stdexcept>
#include <string>

#include "rclcpp/rclcpp.hpp"


int main(int argc, char ** argv)
{
  rclcpp::init(argc, argv);

  auto node = rclcpp::Node::make_shared(std::string("test_parameters_server"));

  // TODO(esteve): Make the parameter service automatically start with the node.
  auto parameter_service = std::make_shared<rclcpp::parameter_service::ParameterService>(node);

  rclcpp::spin(node);

  return 0;
}
