Models權責
無論邏輯的實體(Entity or Service)、資料的模型(DBEntities or other)還是簡單物件(DTO)或純值物件(ValueObject)
其實都是屬於Model
為了避免全部取名為Model造成混淆
資料模型的尾綴使用Model
邏輯的主體的尾綴使用Service
簡單物件或純值物件使用DTO、VO，具有特殊行為搭配(如Request Response...)則各自依行為尾綴命名
