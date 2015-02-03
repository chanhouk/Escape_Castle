public interface ITouchable3D 
{
	//Remove functions you know you arent going to use
	// void OnNoTouches();
	void OnTouchBegan();
	void OnTouchEnded();
	void OnTouchMoved();
	void OnTouchStayed();
	// void OnTouchBeganAnywhere();
	void OnTouchEndedAnywhere();
	void OnTouchMovedAnywhere();
	void OnTouchStayedAnywhere();
}