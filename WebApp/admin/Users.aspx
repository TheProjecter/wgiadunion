<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="admin_Users" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<asp:PlaceHolder ID="plhdTitle" runat="server"></asp:PlaceHolder>
</head>
<body>
    <form id="form" runat="server">

<!--内容区开始-->
	<div id="container">
	  <!--头部开始-->
      <asp:PlaceHolder ID="plhdHeader" runat="server"></asp:PlaceHolder>
	  <!--头部结束-->
      <!--主内容区容器开始-->
        <div id="wrapper">
            <!--左内容区开始-->
            <div id="content">
       			<div id="rightnow">
                    <h3 class="reallynow">
                        <span>操作区</span>
                        <a href="#" class="add">Add New Product</a>
                        <a href="#" class="app_add">Some Action</a>
                        <br />
                    </h3>
				    <p class="youhave">You have <a href="#">19 new orders</a>, <a href="#">12 new users</a> and <a href="#">5 new reviews</a>, today you made <a href="#">$1523.63 in sales</a> and a total of <strong>$328.24 profit </strong>
                    </p>
			  </div>
              <div id="box">
                	<h3>Users</h3>
                	<table width="100%">
						<thead>
							<tr>
                            	<th width="40px"><a href="#">ID<img src="img/icons/arrow_down_mini.gif" width="16" height="16" align="absmiddle" /></a></th>
                            	<th><a href="#">Full Name</a></th>
                                <th><a href="#">Email</a></th>
                                <th width="70px"><a href="#">Group</a></th>
                                <th width="50px"><a href="#">ZIP</a></th>
                                <th width="90px"><a href="#">Registered</a></th>
                                <th width="60px"><a href="#">Action</a></th>
                            </tr>
						</thead>
						<tbody>
							<tr>
                            	<td class="a-center">232</td>
                            	<td><a href="#">Jennifer Hodes</a></td>
                                <td>jennifer.hodes@gmail.com</td>
                                <td>General</td>
                                <td>1000</td>
                                <td>July 2, 2008</td>
                                <td><a href="#"><img src="img/icons/user.png" title="Show profile" width="16" height="16" /></a><a href="#"><img src="img/icons/user_edit.png" title="Edit user" width="16" height="16" /></a><a href="#"><img src="img/icons/user_delete.png" title="Delete user" width="16" height="16" /></a></td>
                            </tr>
							<tr>
                            	<td class="a-center">231</td>
                            	<td><a href="#">Mark Kyrnin</a></td>
                            	<td>mark.kyrnin@hotmail.com</td>
                                <td>Affiliate</td>
                                <td>8310</td>
                                <td>June 17, 2008</td>
                                <td><a href="#"><img src="img/icons/user.png" title="Show profile" width="16" height="16" /></a><a href="#"><img src="img/icons/user_edit.png" title="Edit user" width="16" height="16" /></a><a href="#"><img src="img/icons/user_delete.png" title="Delete user" width="16" height="16" /></a></td>
                            </tr>
							<tr>
                            	<td class="a-center">230</td>
                            	<td><a href="#">Virgílio Cezar</a></td>
                                <td>virgilio@somecompany.cz</td>
                                <td>General</td>
                                <td>6200</td>
                                <td>June 31, 2008</td>
                                <td><a href="#"><img src="img/icons/user.png" title="Show profile" width="16" height="16" /></a><a href="#"><img src="img/icons/user_edit.png" title="Edit user" width="16" height="16" /></a><a href="#"><img src="img/icons/user_delete.png" title="Delete user" width="16" height="16" /></a></td>
                            </tr>
							<tr>
                            	<td class="a-center">229</td>
                            	<td><a href="#">Todd Simonides</a></td>
                                <td>todd.simonides@gmail.com</td>
                                <td>Wholesale</td>
                                <td>2010</td>
                                <td>June 5, 2008</td>
                                <td><a href="#"><img src="img/icons/user.png" title="Show profile" width="16" height="16" /></a><a href="#"><img src="img/icons/user_edit.png" title="Edit user" width="16" height="16" /></a><a href="#"><img src="img/icons/user_delete.png" title="Delete user" width="16" height="16" /></a></td>
                            </tr>
                            <tr>
                            	<td class="a-center">228</td>
                            	<td><a href="#">Carol Elihu</a></td>
                                <td>carol@herbusiness.com</td>
                                <td>General</td>
                                <td>3120</td>
                                <td>May 23, 2008</td>
                                <td><a href="#"><img src="img/icons/user.png" title="Show profile" width="16" height="16" /></a><a href="#"><img src="img/icons/user_edit.png" title="Edit user" width="16" height="16" /></a><a href="#"><img src="img/icons/user_delete.png" title="Delete user" width="16" height="16" /></a></td>
                            </tr>
                            <tr>
                            	<td class="a-center">232</td>
                            	<td><a href="#">Jennifer Hodes</a></td>
                                <td>jennifer.hodes@gmail.com</td>
                                <td>General</td>
                                <td>1000</td>
                                <td>July 2, 2008</td>
                                <td><a href="#"><img src="img/icons/user.png" title="Show profile" width="16" height="16" /></a><a href="#"><img src="img/icons/user_edit.png" title="Edit user" width="16" height="16" /></a><a href="#"><img src="img/icons/user_delete.png" title="Delete user" width="16" height="16" /></a></td>
                            </tr>
							<tr>
                            	<td class="a-center">231</td>
                            	<td><a href="#">Mark Kyrnin</a></td>
                            	<td>mark.kyrnin@hotmail.com</td>
                                <td>Affiliate</td>
                                <td>8310</td>
                                <td>June 17, 2008</td>
                                <td><a href="#"><img src="img/icons/user.png" title="Show profile" width="16" height="16" /></a><a href="#"><img src="img/icons/user_edit.png" title="Edit user" width="16" height="16" /></a><a href="#"><img src="img/icons/user_delete.png" title="Delete user" width="16" height="16" /></a></td>
                            </tr>
							<tr>
                            	<td class="a-center">230</td>
                            	<td><a href="#">Virgílio Cezar</a></td>
                                <td>virgilio@somecompany.cz</td>
                                <td>General</td>
                                <td>6200</td>
                                <td>June 31, 2008</td>
                                <td><a href="#"><img src="img/icons/user.png" title="Show profile" width="16" height="16" /></a><a href="#"><img src="img/icons/user_edit.png" title="Edit user" width="16" height="16" /></a><a href="#"><img src="img/icons/user_delete.png" title="Delete user" width="16" height="16" /></a></td>
                            </tr>
							<tr>
                            	<td class="a-center">229</td>
                            	<td><a href="#">Todd Simonides</a></td>
                                <td>todd.simonides@gmail.com</td>
                                <td>Wholesale</td>
                                <td>2010</td>
                                <td>June 5, 2008</td>
                                <td><a href="#"><img src="img/icons/user.png" title="Show profile" width="16" height="16" /></a><a href="#"><img src="img/icons/user_edit.png" title="Edit user" width="16" height="16" /></a><a href="#"><img src="img/icons/user_delete.png" title="Delete user" width="16" height="16" /></a></td>
                            </tr>
                            <tr>
                            	<td class="a-center">228</td>
                            	<td><a href="#">Carol Elihu</a></td>
                                <td>carol@herbusiness.com</td>
                                <td>General</td>
                                <td>3120</td>
                                <td>May 23, 2008</td>
                                <td><a href="#"><img src="img/icons/user.png" title="Show profile" width="16" height="16" /></a><a href="#"><img src="img/icons/user_edit.png" title="Edit user" width="16" height="16" /></a><a href="#"><img src="img/icons/user_delete.png" title="Delete user" width="16" height="16" /></a></td>
                            </tr>
						</tbody>
					</table>
                    <div id="pager">
                    	Page <a href="#"><img src="img/icons/arrow_left.gif" width="16" height="16" /></a> 
                    	<input size="1" value="1" type="text" name="page" id="page" /> 
                    	<a href="#"><img src="img/icons/arrow_right.gif" width="16" height="16" /></a>of 42
                    pages | View <select name="view">
                    				<option>10</option>
                                    <option>20</option>
                                    <option>50</option>
                                    <option>100</option>
                    			</select> 
                    per page | Total <strong>420</strong> records found
                    </div>
                </div>
                <br />
                <div id="box">
                	<h3 id="adduser">Add user</h3>
                    <form id="form1" action="..." method="post">
                      <fieldset id="personal">
                        <legend>PERSONAL INFORMATION</legend>
                        <label for="lastname">Last name : </label> 
                        <input name="lastname" id="lastname" type="text" tabindex="1" />
                        <br />
                        <label for="firstname">First name : </label>
                        <input name="firstname" id="firstname" type="text" 
                        tabindex="2" />
                        <br />
                        <label for="email">Email : </label>
                        <input name="email" id="email" type="text" 
                        tabindex="2" />
                        <br />
                        <p>Send auto generated password 
                            <input name="generatepass" id="yes" type="checkbox" 
                        value="yes" tabindex="35" /></p>
                        <label for="pass">Password : </label>
                        <input name="pass" id="pass" type="password" 
                        tabindex="2" />
                        <br />
                        <label for="pass-2">Password : </label>
                        <input name="pass-2" id="pass-2" type="password" 
                        tabindex="2" />
                        <br />
                      </fieldset>
                      <fieldset id="address">
                        <legend>Address</legend>
                        <label for="street">Street address : </label> 
                        <input name="street" id="street" type="text" 
                        tabindex="1" />
                        <br />
                        <label for="city">City : </label>
                        <input name="city" id="city" type="text" 
                        tabindex="2" />
                        <br />
                        <label for="country">Country : </label> 
                        <input name="country" id="country" type="text" 
                        tabindex="1" />
                        <br />
                        <label for="state">State/Province : </label>
                        <input name="state" id="state" type="text" 
                        tabindex="2" />
                        <br />
                        <label for="zip">Zip/Postal Code : </label>
                        <input name="zip" id="zip" type="text" 
                        tabindex="2" />
                        <br />
                        <label for="tel">Telephone : </label>
                        <input name="tel" id="tel" type="text" 
                        tabindex="2" />
                      </fieldset>
                      <fieldset id="opt">
                        <legend>OPTIONS</legend>
                        <label for="choice">Group : </label>
                        <select name="choice">
                          <option selected="selected" label="none" value="none">
                          General
                          </option>
                          <optgroup label="Group 1">
                            <option label="cg1a" value="val_1a">Selection group 1a
                            </option>
                            <option label="cg1b" value="val_1b">Selection group 1b
                            </option>
                            <option label="cg1c" value="val_1c">Selection group 1c
                            </option>
                          </optgroup>
                          <optgroup label="Group 2">
                            <option label="cg2a" value="val_2a">Selection group 2a
                            </option>
                            <option label="cg2b" value="val_2a">Selection group 2b
                            </option>
                          </optgroup>
                          <optgroup label="Group 3">
                            <option label="cg3a" value="val_3a">Selection group 3a
                            </option>
                            <option label="cg3a" value="val_3a">Selection group 3b
                            </option>
                          </optgroup>
                        </select>
                      </fieldset>
                      <div align="center">
                      <input id="button1" type="submit" value="Send" /> 
                      <input id="button2" type="reset" />
                      </div>
                    </form>

                </div>
            </div>
            <!--左内容区结束-->
            <!--侧面板开始-->
            <asp:PlaceHolder ID="plhdSlide" runat="server"></asp:PlaceHolder>
            <!--侧面板结束-->
      </div>
      <!--主内容区容器结束-->
      
        <!--脚部开始-->
        <asp:PlaceHolder ID="plhdFooter" runat="server"></asp:PlaceHolder>
        <!--脚部结束-->
</div>
<!--内容区结束-->

    </form>
</body>
</html>
