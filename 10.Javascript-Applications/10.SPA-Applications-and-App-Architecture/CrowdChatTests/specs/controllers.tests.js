define(['chai', 'controllers'], function (chai, controllers){
    var expect = chai.expect;

    describe('#Test', function () {
        it('test sample', function () {
            expect('test').to.be.eql('test');
        })
    });

});