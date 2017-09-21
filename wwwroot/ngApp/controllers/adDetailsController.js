class AdDetailsController {
    constructor($adService, $stateParams) {   //adservice and not category service - yes, thats where the getAd function is
        let id = $stateParams["id"];
        this.ad = $adService.getAd(id);        
    }   
    getImgUrl(images) {
        
                let result = "";        
                try {
                    return images.filter(image => image.isPrimary)[0].url;
                } catch (err) {
                    result = "http://phylinx.com/wp-content/uploads/2015/03/FPO-IMAGE.png";
                }
        
                return result;
            }
}