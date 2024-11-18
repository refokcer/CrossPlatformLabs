using Lab5.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lab1;
using Lab2;
using Lab3;

namespace Lab5.Controllers;

public class LabController : Controller
{
    [Authorize]
    public IActionResult Lab1()
    {
        return View(new IOModel() { Input = "-5\r\n0\r\n1\r\n2\r\n5\r\n10\r\n20\r\n74\r\n108\r\n250"});
    }

    [Authorize]
    [HttpPost]
    public IActionResult Lab1(IOModel model)
    {
        var input = model.Input.Split("\n").ToList();
        var processedInput = input.Select(item => item.Replace("\r", "")).ToList();

        var runner1 = new Lab1Runner();
        var answer = runner1.ProcessInput(runner1.ConvertToLongList(processedInput));
        model.Output = string.Join("\n", answer);

        return View(model);
    }

    [Authorize]
    public IActionResult Lab2()
    {
        return View(new IOModel() { Input = "5\r\na\r\nab\r\nbc\r\nbcd\r\nadd\r\n3\r\na\r\nab\r\nabc" });
    }

    [Authorize]
    [HttpPost]
    public IActionResult Lab2(IOModel model)
    {
        var input = model.Input.Split("\n").ToList();
        var processedInput = input.Select(item => item.Replace("\r", "")).ToList();

        var runner2 = new Lab2Runner();
        var answer = runner2.ProcessInput(runner2.ConvertToLongStringList(processedInput));
        model.Output = string.Join("\n", answer);

        return View(model);
    }

    [Authorize]
    public IActionResult Lab3()
    {
        return View(new IOModel() { Input = "4\r\nA -> B\r\nB -> K\r\nH -> E\r\nK -> H\r\nA\r\nE\r\n4\r\nA -> B\r\nB -> F\r\nF -> E\r\nD -> E\r\nA\r\nE" });
    }

    [Authorize]
    [HttpPost]
    public IActionResult Lab3(IOModel model)
    {
        var input = model.Input.Split("\n").ToList();
        var processedInput = input.Select(item => item.Replace("\r", "")).ToList();

        var runner3 = new Lab3Runner();
        var answer = runner3.ProcessInput(runner3.ConvertToNestedStringList(processedInput));
        model.Output = string.Join("\n", answer);

        return View(model);
    }
}
