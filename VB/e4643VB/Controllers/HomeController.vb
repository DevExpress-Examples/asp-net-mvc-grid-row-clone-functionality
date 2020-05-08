Public Class HomeController
    Inherits System.Web.Mvc.Controller
    Private list As New PersonList()
    Function Index() As ActionResult
        Return View(list.GetPersons())
    End Function

	Public Function GridViewPartial() As ActionResult
		Return PartialView("_GridViewPartial", list.GetPersons())
	End Function

	Public Function CustomGridViewEditingPartial(ByVal key As Integer) As ActionResult
		ViewData("key") = key
		Return PartialView("_GridViewPartial", list.GetPersons())
	End Function

	<HttpPost, ValidateInput(False)>
	Public Function EditingAddNew(ByVal person As Person) As ActionResult
		If ModelState.IsValid Then
			list.AddPerson(person)
		End If
		Return PartialView("_GridViewPartial", list.GetPersons())
	End Function

	<HttpPost, ValidateInput(False)>
	Public Function EditingUpdate(ByVal personInfo As Person) As ActionResult
		If ModelState.IsValid Then
			list.UpdatePerson(personInfo)
		End If
		Return PartialView("_GridViewPartial", list.GetPersons())
	End Function

	Public Function EditingDelete(ByVal personId As Integer) As ActionResult
		list.DeletePerson(personId)
		Return PartialView("_GridViewPartial", list.GetPersons())
	End Function
End Class