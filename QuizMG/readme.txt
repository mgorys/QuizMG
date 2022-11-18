			This is a web application, which uses Model-View-Controller (MVC) design patter.

			Model part is supported by repository-service pattern, which contains businness logic with operations that should be performed by it.

			Repository-Service pattern divides the business layer into two semi-layers. Repository handles getting data into and out of database.

			Service is responsible for operations on data and passing them between repository and controller.
			
			Another important part is usage of routing. Route defines what question should be shown as its id is in URL.cal database.