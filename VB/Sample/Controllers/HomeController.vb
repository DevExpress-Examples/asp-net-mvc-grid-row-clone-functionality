Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports Sample.Models

Namespace Sample.Controllers

    Public Class HomeController
        Inherits Controller

        Private list As PersonsList = New PersonsList()

        Public Function Index() As ActionResult
            Return View(list.GetPersons())
        End Function

        Public Function GridViewEditingPartial() As ActionResult
            Return PartialView(list.GetPersons())
        End Function

        Public Function CustomGridViewEditingPartial(ByVal key As Integer) As ActionResult
            ViewData("key") = key
            Return PartialView("GridViewEditingPartial", list.GetPersons())
        End Function

        <HttpPost, ValidateInput(False)>
        Public Function EditingAddNew(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal person As Person) As ActionResult
            If ModelState.IsValid Then list.AddPerson(person)
            Return PartialView("GridViewEditingPartial", list.GetPersons())
        End Function

        <HttpPost, ValidateInput(False)>
        Public Function EditingUpdate(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal personInfo As Person) As ActionResult
            If ModelState.IsValid Then list.UpdatePerson(personInfo)
            Return PartialView("GridViewEditingPartial", list.GetPersons())
        End Function

        Public Function EditingDelete(ByVal personId As Integer) As ActionResult
            list.DeletePerson(personId)
            Return PartialView("GridViewEditingPartial", list.GetPersons())
        End Function
    End Class
End Namespace
