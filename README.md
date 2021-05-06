# UnitTestSampleWithoutDI
.Net Core 單元測試模型，為了明確看出測試權責範圍而故意不使用DI的版本
  
    
## 測試模型中主專案的架構
![image](https://github.com/sigglas/UnitTestSampleWithoutDI/blob/main/md/ProjectModule.png)

* Controllers不負責任何實際邏輯
* Business負責主要的商業邏輯的整合
* Models負責提供Business所需要的素材

## 開發順序思考

* 不需要從Controller開始開發，等到邏輯驗證成功後才在Controller中加入Flow。
* 因此可以先針對需求去分解項目，從各個Model開始撰寫，完成之後再在Flow中組合，最後註冊到Controller上。
* 讓持續開發時能專注在Flow，而不是處裡MVC間各種雜務


## 帶入單元測試概念

因為可以各自切分Model的關係，我們可以先從Model開始驗證，當驗證各種情況都符合時，在Flow組合時就不需要關注Model。

因此我可以先[測服務]再寫服務，或者也可以先[測流程]再組合流程所需的服務

最後當[流程]與[服務]都沒問題時，我會拿UnitTest專案當作整合測試直接測試Controller(因為方便)

* 如果你的完整整合測試是包含Controller之間的順序，你要撰寫順序的測試也是可以，但應該透過其他自動化測試的系統可能會更好
* 是否要以TDD測試先行來做為開發手段，看個人，因為系統已經可以拆分，故以TDD方式開發應該是可以的。




