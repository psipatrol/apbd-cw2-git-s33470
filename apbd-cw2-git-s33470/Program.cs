using apbd_cw2_git_s33470.equipment;
using apbd_cw2_git_s33470.equipment.camera;
using apbd_cw2_git_s33470.equipment.laptop;
using apbd_cw2_git_s33470.service;
using apbd_cw2_git_s33470.users;

RentalService Service = new RentalService();

AbstractUser Tomek = new Student("Tomek", "Elektronek", "s33123");
AbstractUser Tomeczek = new Employee("Tomeczek", "Zderzacz-Cząsteczek", "CERN");

AbstractEquipment CoolCamera = new CameraBuilder()
    .SetModel("Canon EOS RP")
    .SetSensorType("Full frame")
    .SetValue(4599)
    .Build();
AbstractEquipment MidCamera = new CameraBuilder()
    .SetModel("Nikon")
    .SetSensorType("APS-C")
    .SetValue(3999)
    .Build();
AbstractEquipment VintageCamera = new CameraBuilder()
    .SetModel("Canon AE-1")
    .SetSensorType("SLR")
    .SetValue(899)
    .Build();


AbstractEquipment CoolLaptop = new LaptopBuilder()
    .SetModel("thin one")
    .SetValue(3299)
    .SetCpu("fast")
    .SetGpu("astonishing")
    .SetRamGb(15)
    .Build();
    
Service.ShowAllEquipment();
Service.ShowAvailableEquipment();

Service.RentItem(Tomek, CoolCamera, 14);
Service.RentItem(Tomek, MidCamera, 3);
Service.RentItem(Tomek, VintageCamera, 31);

Service.RentItem(Tomeczek, CoolCamera, 7);
Service.RentItem(Tomeczek, CoolLaptop, 7);

Service.ShowActiveUserRentals(Tomek);
Service.ShowActiveUserRentals(Tomeczek);

Service.ReturnItem(CoolLaptop, DateTime.Now.AddDays(5));
Service.ReturnItem(CoolCamera, DateTime.Now.AddDays(16));

CoolCamera.MarkAsDamaged();
Service.ShowOverdueRentals();

Service.GenerateReport();