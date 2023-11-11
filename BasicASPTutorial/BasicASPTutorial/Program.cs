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

//��˹������ਤ�ѹ���ٻẺ https
app.UseHttpsRedirection();
//�ա�����¡�� static file
app.UseStaticFiles();

//�ա���� routing
app.UseRouting();

//�ա�á�˹��Է�������㹡�èѴ��õ����ਤ
app.UseAuthorization();

//�ա�� map �Ѻ������ controller �Ѻ��� ��鹷ҧ
//HomeController �ա�����¡�� action method ��������� Index (�繵�ǵ�駵鹷����ʴ��˹����红ͧ������ѹ�Ѻ�á)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
