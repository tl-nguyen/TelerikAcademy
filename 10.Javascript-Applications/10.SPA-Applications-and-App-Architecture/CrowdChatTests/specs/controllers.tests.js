define(['chai', 'controllers'], function (chai, controllers){
    var expect = chai.expect;

    describe('#Controllers', function () {
        it('controller is created', function () {
            var controller = controllers.get('fdsaf','#fdafds');
            expect(controller).to.be.ok;
        });

        it('controller is created without url', function () {
            var controller = controllers.get();
            expect(controller.persister.rootUrl).to.be.undefined;
        });

        it('controller is created without selector', function () {
            var controller = controllers.get('http://test');
            expect(controller.selector).to.be.undefined;
        });
    });

});