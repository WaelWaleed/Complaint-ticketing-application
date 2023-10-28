This is a Complaint Ticketing Application, it is designed based on the Repository Design Pattern.
It has 2 main modules (API, UI).

Modules:
  1. API:
     - This is a webapi module that handles requests and returns responses.
     - This module is connected to another 2 modules which are (Entity, DTO):
       
         1.1.1: Entity: It is module that has all the models stored in the database as proxies.
       
         1.1.2: DTO: It the a module that has all the models that need to be sent to User Interface (UI).
       
       - The API module maps the data from DTO to Entity vice versa.
         
         1.2.1: when the data needs to be stored the database the api maps it from DTO to Entity.
         
         1.2.2: when the data is retrieved from the database the api maps it from Entity to DTO.
         
       - The Api is connected to another module name "Repository" which has all the functionalities to manipulate the data in the database.
         
  2. UI :
     
     - This is MVC web application which is responsible of handling the requests from the browser to the api vice versa.
       
     - it has 2 controllers:
       
       Controllers:
     
         2.1: Home Controller: this is the main page.
       
         2.2: Complaint Controller: this is controllers that has the functionalitites of all CRUD Operations for the complaints.
       
           2.2.1: Views:
       
               2.2.1.1: Index: this view displays all the complaints for the admin to approve them on reject them. Also, the user is able to edit his complaint.
       
               2.2.1.2: AddEdit: this is the view that has the complaint form which allows the user to submit a complaint. This view also has a partialview for the                             demands.
       
                         ****Note: you need to press the "plus" icon to add the demands into the table below inorder to be saved as demands for that complaint.****
       
                         once the demand is added, the user can either edit it or delete it by clicking the "Edit" icon and "Delete" icon.
       
                         ****Note: sometimes you need to click the icons twice inorder for functionality to work.****
