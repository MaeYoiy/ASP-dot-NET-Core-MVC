var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//กำหนดตัวโปรเจครันเป็นรูปแบบ https
app.UseHttpsRedirection();
//มีการเรียกใช้ static file
app.UseStaticFiles();

//มีการใช้ routing
app.UseRouting();

//มีการกำหนดสิทธิ์ที่ใช้ในการจัดการตัวโปรเจค
app.UseAuthorization();

//มีการ map จับคู่ชื่อ controller กับคู่ เส้นทาง
//HomeController มีการเรียกใช้ action method ที่ชื่อว่า Index (เป็นตัวตั้งต้นที่จะแสดงในหน้าเว็บของเราเป็นอันดับแรก)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
